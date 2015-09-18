:Ask
set /P INPUT=Version number?: %=%

"H:\Database\packages\FluentMigrator.1.6.0\tools\Migrate.exe"^
 /conn "Data Source=SQL01;Initial Catalog=DigitalTest;Integrated Security=SSPI;"^
 /provider sqlserver2014^
 /assembly "H:\Database\Database\bin\Release\Database.dll"^
 /verbose=true --task rollback:toversion^
 /version=%INPUT%^
 PAUSE