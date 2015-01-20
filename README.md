# DNN.Tool
DNN.Tool is a winforms application that allows you to manipulate your local DNN sites hosted in IIS

Currently you can do three different types of actions:

1. create a clone from a local site

   a) a clone can be a zip archive for later use on a different server
      the archive contains detached database files as well as a copy of the site's file system
      
   b) a clone can also be a new site on the same IIS instance
      the new / cloned site will be an exact copy of the source site, the only difference is that you call the site with the alias of the original site, suffixed with "_clone"

2. create a new site

  a) create a site from a previously created clone archive (see above)
  
  b) create a new site from scratch, i.e. use a regular install package to create a new DNN installation. 
  
3. bulk create user accounts

   when bulk creating accounts it will create the specified number of accounts. the passwords of those accounts will be set to the password of the site's initial superuser account. Names and e-mail addresses are being generated randomly from string arrays set up in the app.config found in the tool's bin directory. 
  
  
#Notes:
- all sites use an application pool in integrated pipeline mode. Its identity is set to "ApplicationPoolIdentity"
- all databases use windows authentication. Therefor make sure you are using this tool through a user account that has full access to your local IIS server. 
- you can only clone / restore sites that are using integrated security when connecting to sql server
- for new sites the tool uses the "ConnectionStringTemplate" setting from app.config in the bin directory of the tool
- the tool uses the "LocalConnectionString" setting from app.config in the bin directory of the tool for connecting to sql server
