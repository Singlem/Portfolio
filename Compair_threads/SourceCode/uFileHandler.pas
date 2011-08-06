unit uFileHandler;

interface
  procedure LoadSettings(var Host, User, Password, Database, port : string; var bCompleted, bLog, bBackUp : Boolean);
  procedure SaveSettings(var Host, User, Password, Database, port, bLog, bBackUP : string);
implementation

uses
  SysUtils, Dialogs;

var
  bWriteLog : Boolean;
  bWriteBackUp : Boolean;

procedure LoadSettings(var Host, User, Password, Database, port : string; var bCompleted, bLog, bBackUp : Boolean);
var
  tSettings : TextFile;
  sLine     : string;
begin
  bCompleted := True;
  AssignFile(tSettings,'Settings.txt');

  if FileExists('Settings.txt') <> True then
    bCompleted := False
  else
    begin
      Reset(tSettings);
      Readln(tSettings,sLine);
      Host := sLine;
      Readln(tSettings,sLine);
      Database := sLine;
      Readln(tSettings,sLine);
      Password := sLine;
      Readln(tSettings,sLine);
      User := sLine;
      Readln(tSettings,sLine);
      port := sLine;
      Readln(tSettings,sLine);
      if sLine = 'True' then bWriteLog := True else bWriteLog := False;
      Readln(tSettings,sLine);
      if sLine = 'True' then bWriteBackUp := True else bWriteLog := False;
      CloseFile(tSettings);
    end;

    bLog := bWriteLog;
    bBackUp := bWriteBackUp;
end;
//-------------------------------------------------------------------

procedure SaveSettings(var Host, User, Password, Database, port, bLog, bBackUP : string);
var
  tSettings : TextFile;
begin
  AssignFile(tSettings,'Settings.txt');
  Rewrite(tSettings);
  Writeln(tSettings,Host);
  Writeln(tSettings,Database);
  Writeln(tSettings,Password);
  Writeln(tSettings,User);
  Writeln(tSettings,port);
  Writeln(tSettings,bLog);
  Writeln(tSettings,bBackUp);
  CloseFile(tSettings);
end;
//-------------------------------------------------------------------

end.
