program pCompair;

uses
  Forms,
  uMain in 'uMain.pas' {frmMain},
  uFileHandler in 'uFileHandler.pas',
  uStructure in 'uStructure.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TfrmMain, frmMain);
  Application.Run;
end.
