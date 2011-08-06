@echo off
setLocal EnableDelayedExpansion

for /f "tokens=* delims= " %%a in (Settings.txt) do (
set /a N+=1
set v!N!=%%a
)
set svr=!v1!
set mangosdb=!v2!
set pass=!v3!
set user=!v4!
set port=!v5!

echo The structure.sql needs to be run atleast 1 time.
echo This for the compairing tool to compair wdb entries to
echo the entries in the database.

echo.
set /p structure=Run structure.sql? [Y]
if %structure% == . set structure=Y  
goto dbupdate

:dbUpdate
cls
if %structure% == Y for %%i in (WDB-Converter\structure.sql) do echo %%i & mysql -q -s -h %svr% --user=%user% --password=%pass% --port=%port% %mangosdb% < %%i
for %%i in (WDB-Converter\SQL\questcache.sql) do echo %%i & mysql -q -s -h %svr% --user=%user% --password=%pass% --port=%port% %mangosdb% < %%i
for %%i in (WDB-Converter\SQL\itemcache.sql) do echo %%i & mysql -q -s -h %svr% --user=%user% --password=%pass% --port=%port% %mangosdb% < %%i
for %%i in (WDB-Converter\SQL\creaturecache.sql) do echo %%i & mysql -q -s -h %svr% --user=%user% --password=%pass% --port=%port% %mangosdb% < %%i
for %%i in (WDB-Converter\SQL\gameobjectcache.sql) do echo %%i & mysql -q -s -h %svr% --user=%user% --password=%pass% --port=%port% %mangosdb% < %%i
for %%i in (WDB-Converter\SQL\npccache.sql) do echo %%i & mysql -q -s -h %svr% --user=%user% --password=%pass% --port=%port% %mangosdb% < %%i
for %%i in (WDB-Converter\SQL\pagetextcache.sql) do echo %%i & mysql -q -s -h %svr% --user=%user% --password=%pass% --port=%port% %mangosdb% < %%i