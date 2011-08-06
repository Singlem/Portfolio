unit uMain;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, DBXpress, FMTBcd, ShellAPI, DB, SqlExpr, StdCtrls, Buttons, sBitBtn,
  sGroupBox, BMDThread, uStructure, sSkinManager, ComCtrls, acProgressBar,
  sPageControl, sRichEdit, sLabel, sButton, ExtCtrls, sPanel, sCheckBox,
  sEdit, uConsoleTools, uFileHandler;

type
  TfrmMain = class(TForm)
    ThreadQuery: TBMDThread;
    rgpCompair: TsRadioGroup;
    bmbProccess: TsBitBtn;
    Connection: TSQLConnection;
    SQLQuery1: TSQLQuery;
    ThreadCompair: TBMDThread;
    sknMain: TsSkinManager;
    pgeMain: TsPageControl;
    Compairer: TsTabSheet;
    pgeData: TsPageControl;
    Comapair: TsTabSheet;
    pbMain: TsProgressBar;
    pgeOutput: TsPageControl;
    OutPut: TsTabSheet;
    redMain: TsRichEdit;
    lblCount: TsLabelFX;
    WDB: TsTabSheet;
    pnl1: TsPanel;
    redWDB: TsRichEdit;
    btnWDB: TsButton;
    btnImport: TsButton;
    More: TsTabSheet;
    Settings: TsTabSheet;
    edtHost: TsEdit;
    edtDatabase: TsEdit;
    edtUser: TsEdit;
    edtPassword: TsEdit;
    edtPort: TsEdit;
    chkLog: TsCheckBox;
    chkBackUp: TsCheckBox;
    btnSave: TsButton;
    lblHost: TsLabel;
    lblDatabase: TsLabel;
    lblUser: TsLabel;
    lblPass: TsLabel;
    lblPort: TsLabel;
    conImport: TConsoleProcess;
    procedure QueryMain(Sender: TObject);
    procedure QueryTemp(Sender: TObject);
    procedure Compair(Sender: TObject);
    procedure WriteUpdate(Sender: TObject);
    procedure WriteBackUp(Sender: TObject);
    procedure WriteLog(Sender: TObject);
    procedure SaveToFile(Sender: TObject);
    procedure ThreadQueryExecute(Sender: TObject;
      Thread: TBMDExecuteThread; var Data: Pointer);
    procedure ThreadCompairExecute(Sender: TObject;
      Thread: TBMDExecuteThread; var Data: Pointer);
    procedure bmbProccessClick(Sender: TObject);
    procedure UpdateForm(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure TestString(Sender: TObject);
    procedure ThreadCompairTerminate(Sender: TObject;
      Thread: TBMDExecuteThread; var Data: Pointer);
    procedure DataTester(Sender: TObject);
    procedure ThreadQueryTerminate(Sender: TObject;
      Thread: TBMDExecuteThread; var Data: Pointer);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);
    procedure btnWDBClick(Sender: TObject);
    procedure btnImportClick(Sender: TObject);
    procedure conImportStdOut(const AText: String);
    procedure btnSaveClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmMain: TfrmMain;

implementation

{$R *.dfm}
type
  CreatureArray = array[0..23] of string;
  GameobjectArray = array[0..37] of string;
  QuestArray = array[0..84] of string;
  ItemArray = array[0..125] of string;
  NpcTextArray = array[0..80] of string;
  PageTextArray = array[0..2] of string;

var
  sTable, sEntry, sColumn, sString : string;
  bCorrect : Boolean;
  iCount, iLoopCount, iProgress : integer;
  aStruc, aTemp, aMain, aComTemp, aComMain : array[0..125] of string;
  Creature_templateStruc : CreatureArray;
  gameobject_templateStruc : GameobjectArray;
  quest_templateStruc : QuestArray;
  item_templateStruc : ItemArray;
  NpcTextStruc : NpcTextArray;
  PageTextStruc : PageTextArray;

procedure Connect;
begin
  frmMain.Connection.DriverName := 'dbxmysql';
  frmMain.Connection.GetDriverFunc := 'getSQLDriverMYSQL50';
  frmMain.Connection.LibraryName := 'dbxopenmysql50.dll';
  frmMain.Connection.VendorLib := 'libmysql.dll';
  frmMain.Connection.Params.Append('Database=' + frmMain.edtDatabase.text);
  frmMain.Connection.Params.Append('User_Name=' + frmMain.edtUser.text);
  frmMain.Connection.Params.Append('Password=' + frmMain.edtPassword.text);
  frmMain.Connection.Params.Append('HostName=' + frmMain.edtHost.text);
  frmMain.Connection.open;
  MessageDlg('Connected',mtInformation,[mbOK],0);
end;
//---------------------------------------------------------  

procedure GetSettings;
//Load settings
var
  Host, User, Password, Database, port : string;
  bCompleted, bLog, bBackUp : Boolean;
begin
  LoadSettings(Host, User, Password, Database, port, bCompleted, bLog, bBackUp);
  if bLog = True then frmMain.chkLog.Checked := True;
  if bBackUp = True then frmMain.chkBackUp.Checked := True;

  if bCompleted = True then
    begin
      frmMain.edtHost.Text := Host;
      frmMain.edtuser.Text := User;
      frmMain.edtPassword.Text := Password;
      frmMain.edtDatabase.Text := Database;
      frmMain.edtPort.Text := port;
      Connect;
    end
  else
    begin
      MessageDlg('Please check settings for connection to Database',mtInformation,[mbOK],0);
      frmMain.pgeMain.TabIndex := 0;
      frmMain.pgeData.TabIndex := 1;
    end;
end;
//-------------------------------------------------------------------

procedure GetStructure;
//Sends data to uStructure
var
  bComplete : Boolean;
begin
  LoadStructure(Creature_templateStruc,gameobject_templateStruc,quest_templateStruc,
  item_templateStruc,NpcTextStruc,PageTextStruc, bComplete);

  if bComplete = True then
    MessageDlg('Structures loaded',mtInformation,[mbOK],0)
  else
    begin
      MessageDlg('Failed to load Structures. Please Check Structures.txt',mtError,[mbOK],0);
      Application.Terminate;
    end;
end;
//-------------------------------------------------------------------

procedure TfrmMain.QueryTemp(Sender: TObject);
var
  x : byte;
begin
  if sTable = 'creature_template' then
    begin
      frmMain.SQLQuery1.SQL.Text := 'SELECT *,IFNULL(IconName,'''') as IconnameTemp, IFNULL(subname,'''') as subnameTemp FROM ' + sTable + 'temp LIMIT 1';
      frmMain.SQLQuery1.Active := True;
    end
  else
    if sTable = 'gameobject_template' then
      begin
        frmMain.SQLQuery1.SQL.Text := 'SELECT *,IFNULL(IconName,'''') as IconnameTemp,IFNULL(CastBarCaption,'''') as CastBarCaptionTemp,IFNULL(Unk1,'''') as Unk1Temp FROM ' + sTable + 'temp LIMIT 1';
        frmMain.SQLQuery1.Active := True;
      end
    else
      begin
        frmMain.SQLQuery1.SQL.Text := 'SELECT * FROM ' + sTable + 'temp LIMIT 1';
        frmMain.SQLQuery1.Active := True;
      end;

  for x := 0 to iCount do
    aTemp[x] := frmMain.SQLQuery1.FieldValues[aStruc[x]];

  sEntry := frmMain.SQLQuery1.FieldValues[aStruc[0]];

  frmMain.SQLQuery1.SQL.Text := 'DELETE FROM ' + sTable + 'temp LIMIT 1';
  frmMain.SQLQuery1.ExecSQL(True);
end;
//---------------------------------------------------------

procedure TfrmMain.QueryMain(Sender: TObject);
var
  sTemp : string;
  x : byte;
begin
  if sTable = 'creature_template' then
    begin
      frmMain.SQLQuery1.SQL.Text := 'SELECT *,IFNULL(IconName,'''') as IconnameTemp, IFNULL(subname,'''') as subnameTemp FROM ' + sTable + ' WHERE entry=' + sEntry + ';';
      frmMain.SQLQuery1.Active := True;
    end
  else
    if sTable = 'gameobject_template' then
      begin
        frmMain.SQLQuery1.SQL.Text := 'SELECT *,IFNULL(IconName,'''') as IconnameTemp,IFNULL(CastBarCaption,'''') as CastBarCaptionTemp,IFNULL(Unk1,'''') as Unk1Temp FROM ' + sTable + ' WHERE entry=' + sEntry + ';';
        frmMain.SQLQuery1.Active := True;
      end
    else
      if sTable = 'npc_text' then
        begin
          frmMain.SQLQuery1.SQL.Text := 'SELECT * FROM ' + sTable + ' WHERE id=' + sEntry + ';';
          frmMain.SQLQuery1.Active := True;
        end
      else
        begin
          frmMain.SQLQuery1.SQL.Text := 'SELECT * FROM ' + sTable + ' WHERE entry=' + sEntry + ';';
          frmMain.SQLQuery1.Active := True;
        end;

    if frmMain.SQLQuery1.RecordCount = 0 then
    begin
      sTemp := 'SET ';
      for x := 0 to (iCount-1) do
        sTemp := sTemp + aStruc[x] + '=' + aTemp[x] + ',';

      sTemp := sTemp + aStruc[iCount] + '=''' + aTemp[iCount] + ''';';
      sString := 'INSERT INTO ' + sTable + ' ' +  sTemp;
      ThreadQuery.Thread.Synchronize(SaveToFile);
      Exit;
    end;

  for x := 0 to iCount do
    aMain[x] := frmMain.SQLQuery1.FieldValues[aStruc[x]];

  frmMain.SQLQuery1.Active := False;
end;
//---------------------------------------------------------

procedure TfrmMain.Compair(Sender: TObject);
var
  x : byte;
  bDiff : Boolean;
begin
  bDiff := False;
  for x := 0 to iCount do
  begin
    if aComTemp[x] <> aComMain[x] then
      begin
        bDiff := True;
        bCorrect := True;
        sColumn := aStruc[x];
        sString := aComTemp[x];
        if (sTable = 'gameobject_template') OR (sTable = 'quest_template') then
          ThreadCompair.Thread.Synchronize(DataTester);

        if bCorrect = True then
          begin
            ThreadCompair.Thread.Synchronize(WriteUpdate);
            sString := aComMain[x];
            ThreadCompair.Thread.Synchronize(WriteBackUp);
            sString :=  aStruc[x] + '=''' + aComMain[x] + ''' While in the WDB the value is ''' + aComTemp[x] + ''';';
            ThreadCompair.Thread.Synchronize(writeLog);
          end
        else
          bDiff := False;
      end;
  end;

  if bDiff = False then
    begin
      sString := sEntry + ' in ' + sTable + ' is OK';
      ThreadCompair.Thread.Synchronize(writeLog);
    end;
end;
//---------------------------------------------------------

procedure TfrmMain.WriteUpdate(Sender: TObject);
var
  tFile : TextFile;
  sFile : string;
begin
  if Length(sString) > 10 then
    ThreadCompair.Thread.Synchronize(TestString);

  if (sTable = 'gameobject_template') OR (sTable = 'creature_template') then
    if sColumn = 'subnameTemp' then
      sColumn := 'subname'
    else
    if sColumn = 'IconNameTemp' then
      sColumn := 'IconName'
    else
    if sColumn = 'CastBarCaptionTemp' then
      sColumn := 'CastBarCaption'
    else
    if sColumn = 'Unk1Temp' then
      sColumn := 'Unk1';

  If sTable = 'npc_text'  then
    sString := 'UPDATE ' + sTable + ' SET ' + sColumn + '=''' + sString + ''' WHERE id=' + sEntry +';'
  else
    sString := 'UPDATE ' + sTable + ' SET ' + sColumn + '=''' + sString + ''' WHERE entry=' + sEntry +';';

  sFile := changeFileExt(sTable,'.sql');
  AssignFile(tFile,'SQL/' + sFile);

  if FileExists('SQL/' + sFile) <> True then
    rewrite(tFile)
  else
    Append(tFile);

  Writeln(tFile,sString);

  CloseFile(tFile);
end;
//---------------------------------------------------------

procedure TfrmMain.WriteBackUp(Sender: TObject);
var
  tFile : TextFile;
  sFile : string;
begin
  if Length(sString) > 10 then
    ThreadCompair.Thread.Synchronize(TestString);

  if sColumn = 'subnameTemp' then
    sColumn := 'subname'
  else
  if sColumn = 'IconNameTemp' then
    sColumn := 'IconName'
  else
  if sColumn = 'CastBarCaptionTemp' then
    sColumn := 'CastBarCaption'
  else
  if sColumn = 'Unk1Temp' then
    sColumn := 'Unk1';

  If stable = 'npc_text'  then
    sString := 'UPDATE ' + sTable + ' SET ' + sColumn + '=''' + sString + ''' WHERE id=' + sEntry +';'
  else
    sString := 'UPDATE ' + sTable + ' SET ' + sColumn + '=''' + sString + ''' WHERE entry=' + sEntry +';';

  sFile := changeFileExt(sTable + '_BackUp','.sql');
  AssignFile(tFile,'SQL/' + sFile);

  if FileExists('SQL/' + sFile) <> True then
    rewrite(tFile)
  else
    Append(tFile);

  Writeln(tFile,sString);

  CloseFile(tFile);
end;
//---------------------------------------------------------

procedure TfrmMain.WriteLog(Sender: TObject);
var
  tLog : TextFile;
  sFile : string;
begin

  sFile := changeFileExt('log','.log');
  AssignFile(tLog,sFile);

  If FileExists(sFile) <> True then
    Rewrite(tLog)
  else
    Append(tLog);

  sString := DateTimeToStr(Now) + ' ' + sString + ' in table: ' + sTable;

  Writeln(tLog,sString);

  CloseFile(tLog);
end;
//---------------------------------------------------------

procedure TfrmMain.SaveToFile(Sender: TObject);
var
  tFile : TextFile;
  sFile : string;
begin

  sFile := changeFileExt(sTable,'.sql');
  AssignFile(tFile,'SQL/' + sFile);

  if FileExists('SQL/' + sFile) <> True then
    rewrite(tFile)
  else
    Append(tFile);

  Writeln(tFile,sString);

  CloseFile(tFile);
end;
//---------------------------------------------------------

procedure TfrmMain.ThreadQueryExecute(Sender: TObject; Thread: TBMDExecuteThread; var Data: Pointer);
var
  x : integer;
begin
  for x := 1 to iLoopCount do
    begin

      Thread.Synchronize(QueryTemp);
      Thread.Synchronize(QueryMain);

      if ThreadCompair.runing <> True then
        ThreadCompair.Start()
      else
          ThreadCompair.Thread.Resume;
      Thread.Suspend;
    end;
end;
//---------------------------------------------------------

procedure TfrmMain.ThreadCompairExecute(Sender: TObject; Thread: TBMDExecuteThread; var Data: Pointer);
var
  x : integer;
begin
    for x := 1 to iLoopCount do
    begin
      aComTemp := aTemp;
      aComMain := aMain;
      Sleep(10);
      Thread.Synchronize(Compair);
      ThreadQuery.Thread.Resume;
      Thread.Synchronize(UpdateForm);

      if x <> iLoopCount then
        Thread.Suspend;
    end;

    bmbProccess.Enabled := True;
    btnImport.Enabled := True;
    redMain.Lines.Add('Proccessed ' + IntToStr(iLoopCount) + ' entries in ' + sTable);
    redMain.Lines.Add('--------------------------------------------------------');
    EnableMenuItem( GetSystemMenu( handle, False ), SC_CLOSE, MF_BYCOMMAND or MF_ENABLED );
end;
//---------------------------------------------------------

procedure TfrmMain.bmbProccessClick(Sender: TObject);
var
  x, y : Byte;
begin
  EnableMenuItem( GetSystemMenu( handle, False ),SC_CLOSE, MF_BYCOMMAND or MF_GRAYED );
  bmbProccess.Enabled := False;
  btnImport.Enabled := False;
  iProgress := 0;
  pbMain.Position := 0;

  if rgpCompair.ItemIndex = 0 then
    begin
      sTable := 'creature_template';
      frmMain.SQLQuery1.SQL.Text := 'SELECT * FROM creature_templateTemp';
      frmMain.SQLQuery1.Active := True;
      iLoopCount := frmMain.SQLQuery1.RecordCount;
      iCount := 23;
      pbMain.Max := iLoopCount;

      if SQLQuery1.RecordCount <> 0 then
        begin
          for x := 0 to iCount do
            begin
              aStruc[x] := Creature_templateStruc[x];
            end;
          ThreadQuery.Start();
        end
      else
      begin
        bmbProccess.Enabled := True;
        redMain.Lines.Add('Proccessed ' + IntToStr(iLoopCount) + ' entries in ' + sTable);
        redMain.Lines.Add('--------------------------------------------------------');
        EnableMenuItem( GetSystemMenu( handle, False ), SC_CLOSE, MF_BYCOMMAND or MF_ENABLED );
        exit;
        end;
       end;

    if rgpCompair.ItemIndex = 1 then
      begin
        sTable := 'item_template';
        frmMain.SQLQuery1.SQL.Text := 'SELECT * FROM item_templateTemp';
        frmMain.SQLQuery1.Active := True;
        iLoopCount := frmMain.SQLQuery1.RecordCount;
        iCount := 125;
        pbMain.Max := iLoopCount;

        if SQLQuery1.RecordCount <> 0 then
          begin
            for x := 0 to iCount do
              begin
                aStruc[x] := item_templateStruc[x];
              end;
            ThreadQuery.Start();
          end
        else
          begin
            bmbProccess.Enabled := True;
            redMain.Lines.Add('Proccessed ' + IntToStr(iLoopCount) + ' entries in ' + sTable);
            redMain.Lines.Add('--------------------------------------------------------');
            EnableMenuItem( GetSystemMenu( handle, False ), SC_CLOSE, MF_BYCOMMAND or MF_ENABLED );
            exit;
          end;
      end;

    if rgpCompair.ItemIndex = 2 then
      begin
        sTable := 'gameobject_template';
        frmMain.SQLQuery1.SQL.Text := 'SELECT * FROM gameobject_templateTemp';
        frmMain.SQLQuery1.Active := True;
        iLoopCount := frmMain.SQLQuery1.RecordCount;
        iCount := 37;
        pbMain.Max := iLoopCount;

        if SQLQuery1.RecordCount <> 0 then
          begin
            for x := 0 to iCount do
              begin
                aStruc[x] := gameobject_templateStruc[x];
              end;
            ThreadQuery.Start();
          end
        else
          begin
            bmbProccess.Enabled := True;
            redMain.Lines.Add('Proccessed ' + IntToStr(iLoopCount) + ' entries in ' + sTable);
            redMain.Lines.Add('--------------------------------------------------------');
            EnableMenuItem( GetSystemMenu( handle, False ), SC_CLOSE, MF_BYCOMMAND or MF_ENABLED );
            exit;
          end;
      end;

    if rgpCompair.ItemIndex = 3 then
      begin
        sTable := 'quest_template';
        frmMain.SQLQuery1.SQL.Text := 'SELECT * FROM quest_templateTemp';
        frmMain.SQLQuery1.Active := True;
        iLoopCount := frmMain.SQLQuery1.RecordCount;
        iCount := 84;
        pbMain.Max := iLoopCount;

        if SQLQuery1.RecordCount <> 0 then
          begin
            for x := 0 to iCount do
              begin
                aStruc[x] := quest_templateStruc[x];
              end;
            ThreadQuery.Start();
          end
        else
          begin
            bmbProccess.Enabled := True;
            redMain.Lines.Add('Proccessed ' + IntToStr(iLoopCount) + ' entries in ' + sTable);
            redMain.Lines.Add('--------------------------------------------------------');
            EnableMenuItem( GetSystemMenu( handle, False ), SC_CLOSE, MF_BYCOMMAND or MF_ENABLED );
            exit;
          end;
      end;

    if rgpCompair.ItemIndex = 4 then
      begin
        sTable := 'npc_text';
        frmMain.SQLQuery1.SQL.Text := 'SELECT * FROM npc_textTemp';
        frmMain.SQLQuery1.Active := True;
        iLoopCount := frmMain.SQLQuery1.RecordCount;
        iCount := 80;
        pbMain.Max := iLoopCount;

        if SQLQuery1.RecordCount <> 0 then
          begin
            for x := 0 to iCount do
              begin
                aStruc[x] := NpcTextStruc[x];
              end;
            ThreadQuery.Start();
          end
        else
          begin
            bmbProccess.Enabled := True;
            redMain.Lines.Add('Proccessed ' + IntToStr(iLoopCount) + ' entries in ' + sTable);
            redMain.Lines.Add('--------------------------------------------------------');
            EnableMenuItem( GetSystemMenu( handle, False ), SC_CLOSE, MF_BYCOMMAND or MF_ENABLED );
            exit;
          end;
      end;

    if rgpCompair.ItemIndex = 5 then
      begin
        sTable := 'page_text';
        frmMain.SQLQuery1.SQL.Text := 'SELECT * FROM page_textTemp';
        frmMain.SQLQuery1.Active := True;
        iLoopCount := frmMain.SQLQuery1.RecordCount;
        iCount := 2;
        pbMain.Max := iLoopCount;

        if SQLQuery1.RecordCount <> 0 then
          begin
            for x := 0 to iCount do
              begin
                aStruc[x] :=PageTextStruc[x];
              end;
            ThreadQuery.Start();
          end
        else
          begin
            bmbProccess.Enabled := True;
            redMain.Lines.Add('Proccessed ' + IntToStr(iLoopCount) + ' entries in ' + sTable);
            redMain.Lines.Add('--------------------------------------------------------');
            EnableMenuItem( GetSystemMenu( handle, False ), SC_CLOSE, MF_BYCOMMAND or MF_ENABLED );
            exit;
          end;
      end;

    if rgpCompair.ItemIndex = 6 then
      begin
        for y := 0 to 5 do
          begin
            pbMain.Min := 0;
            rgpCompair.ItemIndex := y;
            bmbProccess.Click;
          end;
      end;
end;
//---------------------------------------------------------

procedure TfrmMain.UpdateForm(Sender: TObject);
begin
  Inc(iProgress);
  pbMain.StepIt;
  lblCount.Caption := IntToStr(iProgress) + '/' + IntToStr(iLoopCount);
end;
//---------------------------------------------------------

procedure TfrmMain.FormCreate(Sender: TObject);
begin
  GetStructure;
  GetSettings;
  CreateDir('SQL');
end;
//---------------------------------------------------------

procedure TfrmMain.TestString(Sender: TObject);
var
  sTemp : string;
  sTemp2 : string;
  iLength : integer;
begin

  sTemp2  := sString;

  if Pos('''',sTemp2) <> 0 then
    begin
      iLength := Length(sString);
      sString := '';

      while Pos('''',sTemp2) <> 0 do
        begin
          sTemp := Copy(sTemp2,1,Pos('''',sTemp2)-1);
          sString := sString + sTemp + '\''';
          Delete(sTemp2,1,Pos('''',sTemp2));
        end;

       sString := sString + Copy(sTemp2,1,iLength-(Length(sString))+1);
    end;
end;
//-------------------------------------------------------------------

procedure TfrmMain.ThreadCompairTerminate(Sender: TObject;
  Thread: TBMDExecuteThread; var Data: Pointer);
begin
  bmbProccess.Enabled := True;
end;
//-------------------------------------------------------------------

procedure TfrmMain.DataTester(Sender: TObject);
var
  sTest : string;
begin
  sTest := Copy(sColumn,1,17);
  if sTest = 'ReqCreatureOrGOId' then
    begin
      if sString < inttostr(0) then
        bCorrect := False;
    end;

  if (sTable = 'gameobject_template') AND (sColumn = 'type') AND (sString = '3') then
    bCorrect := false; 
end;
//-------------------------------------------------------------------

procedure TfrmMain.ThreadQueryTerminate(Sender: TObject;
  Thread: TBMDExecuteThread; var Data: Pointer);
begin
  bmbProccess.Enabled := True;
end;
//-------------------------------------------------------------------

procedure TfrmMain.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  if ThreadCompair.Runing = True then
    begin
      ThreadCompair.Thread.Terminate;
      ThreadCompair.Stop;
    end;

  if ThreadQuery.Runing = True then
    begin
      ThreadQuery.Thread.Terminate;
      ThreadQuery.Stop;
    end;

  Application.Terminate;
end;
//-------------------------------------------------------------------

procedure TfrmMain.btnWDBClick(Sender: TObject);
begin
  if FileExists(ExtractFileDir(Application.ExeName) + '\WDB-Converter\MaNGOS WDB Converter.exe') <> True then
    begin
      MessageDlg('Missing the WDB converter files',mtInformation,[mbOK],0);
      Exit;
    end;

  shellexecute(handle,'open',PChar(ExtractFileDir(Application.ExeName) + '\WDB-Converter\MaNGOS WDB Converter.exe'),PChar(ExtractFileDir(Application.ExeName) + '\WDB-Converter'),PChar(ExtractFileDir(Application.ExeName) + '\WDB-Converter'),sw_normal);
end;
//-------------------------------------------------------------------

procedure TfrmMain.btnImportClick(Sender: TObject);
begin
  if FileExists('import.bat') <> True then
    begin
      MessageDlg('Missing file: ''import.bat''...Please add file',mtError,[mbOK],0);
      Exit;
    end;

  conImport.CurrentDir := ExtractFileDir(Application.ExeName);
  conImport.CommandLine := 'import.bat';
  conImport.Execute;

  if MessageDlg('Do you want to run the structure.sql?',mtConfirmation,mbOKCancel,0) = mrOK then
    conImport.Input('Y' + #10#13)
  else
    conImport.Input('N' + #10#13);

  MessageDlg('Data was imported to Database',mtInformation,[mbOK],0);
  pgeData.TabIndex := 0;
  pgeMain.TabIndex := 0;
end;
//-------------------------------------------------------------------

procedure TfrmMain.conImportStdOut(const AText: String);
begin
  redWDB.Lines.add(AText);
end;
//-------------------------------------------------------------------

procedure TfrmMain.btnSaveClick(Sender: TObject);
//Save Settings
var
  Host, User, Password, Database, port : string;
  bLog, bBackUp : string;
begin
  Host := edtHost.Text;
  User := edtuser.Text;
  Password := edtPassword.Text;
  Database := edtDatabase.Text;
  port := edtPort.Text;

  if chkLog.Checked = True then bLog := 'True' else bLog := 'False';
  if chkBackUp.Checked = True then bBackUp := 'True' else bBackUp := 'False';

  SaveSettings(Host, User, Password, Database, port, bLog, bBackUP);
  MessageDlg('Settings Saved',mtInformation,[mbOK],0);
  Connect;
  pgeMain.TabIndex := 0;
  pgeData.TabIndex := 0;
end;
//-------------------------------------------------------------------

end.
