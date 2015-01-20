Imports System.ComponentModel
Imports Microsoft.ApplicationBlocks.Data
Imports DNNTool.Entities

Namespace Services
    Public Class UserCreator

        Private Shared _randomFirstname As Random = Nothing
        Private Shared _randomLastname As Random = Nothing
        Private Shared _randomDomain As Random = Nothing

        Private Shared _connection As SqlClient.SqlConnection
        Private Shared _sampleUser As User

        Public Shared Function Work(ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs) As String

            Dim args As UserCreateArgs = CType(e.Argument, UserCreateArgs)
            _connection = args.Connection
            _sampleUser = GetSampleUser(args.PortalId)

            If args.CleanUpFirst AndAlso Not _sampleUser Is Nothing Then
                CleanUp(args.PortalId)
            End If

            _randomDomain = New Random()
            _randomFirstname = New Random()
            _randomLastname = New Random()

            For i As Integer = 1 To args.Accounts

                If worker.CancellationPending Then
                    e.Cancel = True
                Else
                    If CreateAccount(i, args.PortalId) Then

                        Dim percentage As Integer = (CSng(i) / CSng(args.Accounts)) * 100
                        worker.ReportProgress(percentage)

                    End If
                End If


            Next

            Return String.Format("{0} accounts created", args.Accounts.ToString)

        End Function

        Private Shared Sub CleanUp(PortalId As Integer)

            Dim sql As String = "delete from users where userid <> " & _sampleUser.DNNUserId
            SqlHelper.ExecuteNonQuery(_connection, CommandType.Text, sql)

            sql = "delete from aspnet_membership where userid <> '" & _sampleUser.UserId & "'"
            SqlHelper.ExecuteNonQuery(_connection, CommandType.Text, sql)

            sql = "delete from aspnet_users where userid <> '" & _sampleUser.UserId & "'"
            SqlHelper.ExecuteNonQuery(_connection, CommandType.Text, sql)

        End Sub

        Private Shared Function GetSampleUser(PortalId As Integer) As User

            Dim user As New User
            Dim sql As String = "Select TOP 1 * FROM aspnet_Users"
            Dim dr As IDataReader = SqlHelper.ExecuteReader(_connection, CommandType.Text, sql)
            While dr.Read
                user.ApplicationId = Convert.ToString(dr("ApplicationId"))
                user.UserId = Convert.ToString(dr("UserId"))
                user.UserName = Convert.ToString(dr("UserName"))
            End While
            dr.Close()
            dr.Dispose()

            sql = "select * from aspnet_Membership where UserId = '" & user.UserId & "' and ApplicationId = '" & user.ApplicationId & "'"
            dr = SqlHelper.ExecuteReader(_connection, CommandType.Text, sql)
            While dr.Read
                user.Password = Convert.ToString(dr("Password"))
                user.PasswordSalt = Convert.ToString(dr("PasswordSalt"))
                user.PasswordAnswer = Convert.ToString(dr("PasswordAnswer"))
                user.PasswordQuestion = Convert.ToString(dr("PasswordQuestion"))
                user.Email = Convert.ToString(dr("Email"))
            End While
            dr.Close()
            dr.Dispose()

            sql = "select ApplicationName from aspnet_Applications where ApplicationId = '" & user.ApplicationId & "'"
            dr = SqlHelper.ExecuteReader(_connection, CommandType.Text, sql)
            While dr.Read
                user.ApplicationName = Convert.ToString(dr("ApplicationName"))
            End While
            dr.Close()
            dr.Dispose()

            sql = "select PropertyDefinitionId from ProfilePropertyDefinition where PropertyName = 'FirstName' and PortalId = " & PortalId
            dr = SqlHelper.ExecuteReader(_connection, CommandType.Text, sql)
            While dr.Read
                user.FirstnamePropertyId = Convert.ToInt32(dr("PropertyDefinitionId"))
            End While
            dr.Close()
            dr.Dispose()

            sql = "select PropertyDefinitionId from ProfilePropertyDefinition where PropertyName = 'LastName' and PortalId = " & PortalId
            dr = SqlHelper.ExecuteReader(_connection, CommandType.Text, sql)
            While dr.Read
                user.LastnamePropertyId = Convert.ToInt32(dr("PropertyDefinitionId"))
            End While
            dr.Close()
            dr.Dispose()

            sql = "select top 1 userid from users where email = '" & user.Email & "'"
            dr = SqlHelper.ExecuteReader(_connection, CommandType.Text, sql)
            While dr.Read
                user.DNNUserId = Convert.ToInt32(dr("userid"))
            End While
            dr.Close()
            dr.Dispose()

            Return user

        End Function

        Private Shared Function CreateAccount(index As Integer, PortalId As Integer) As Boolean

            If Not _sampleUser Is Nothing Then

                Dim u As New User
                u.ApplicationName = _sampleUser.ApplicationName
                u.UserName = String.Format("{0}{1}", My.Settings.Username, index.ToString)
                u.Password = _sampleUser.Password
                u.PasswordSalt = _sampleUser.PasswordSalt
                u.PasswordQuestion = _sampleUser.PasswordQuestion

                u.Firstname = My.Settings.Firstnames(_randomFirstname.Next(My.Settings.Firstnames.Count))
                u.Lastname = My.Settings.LastNames(_randomLastname.Next(My.Settings.LastNames.Count))
                u.Email = String.Format("{0}.{1}.{2}@{3}", u.Firstname, u.Lastname, index.ToString, My.Settings.EmailDomains(_randomDomain.Next(My.Settings.EmailDomains.Count)))

                SqlHelper.ExecuteScalar(_connection, "aspnet_Membership_CreateUser", u.ApplicationName, u.UserName, u.Password, u.PasswordSalt, u.Email, u.PasswordQuestion, u.PasswordAnswer, True, Date.UtcNow, Date.Now, 0, 0, Guid.NewGuid())

                Dim displayname As String = String.Format("{0}.{1}.{2}", u.Firstname, u.Lastname, index.ToString)

                Dim dnnuserid As Integer = CType(SqlHelper.ExecuteScalar(_connection, "AddUser", PortalId, u.UserName, u.Firstname, u.Lastname, -1, 0, u.Email, displayname, 0, 1, 1), Integer)
                SqlHelper.ExecuteScalar(_connection, "UpdateUserProfileProperty", DBNull.Value, dnnuserid, _sampleUser.FirstnamePropertyId, u.Firstname, 1, "", Date.Now)
                SqlHelper.ExecuteScalar(_connection, "UpdateUserProfileProperty", DBNull.Value, dnnuserid, _sampleUser.LastnamePropertyId, u.Lastname, 1, "", Date.Now)
                SqlHelper.ExecuteScalar(_connection, "AddUserRole", Portalid, dnnuserid, 1, 1, 0, DBNull.Value, DBNull.Value, _sampleUser.DNNUserId)

            End If

            Return True

        End Function

    End Class
End Namespace

