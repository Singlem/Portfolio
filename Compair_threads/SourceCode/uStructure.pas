unit uStructure;

interface
  procedure LoadStructure(var Creature_templateStruc,gameobject_templateStruc,quest_templateStruc,
  item_templateStruc,NpcTextStruc,PageTextStruc : array of string; var bComplete : Boolean);

implementation
  
uses
  SysUtils;

procedure LoadStructure(var Creature_templateStruc,gameobject_templateStruc,quest_templateStruc,
item_templateStruc,NpcTextStruc,PageTextStruc : array of string; var bComplete : Boolean);
//Loads data from Structures.txt and sendback to uMain
var
  tStructure : TextFile;
  x : Byte;
begin
  bComplete := True;
  AssignFile(tStructure,'Structures.txt');

  if FileExists('Structures.txt') <> True then
      bComplete := False
  else
    Reset(tStructure);

  Readln(tStructure);

  for x := 0 to 23 do
    begin
      Readln(tStructure,Creature_templateStruc[x]);
    end;

  Readln(tStructure);

  for x := 0 to 37 do
    begin
      Readln(tStructure,gameobject_templateStruc[x]);
    end;

  Readln(tStructure);

  for x := 0 to 84 do
    begin
      Readln(tStructure,quest_templateStruc[x]);
    end;

  Readln(tStructure);

  for x := 0 to 125 do
    begin
      Readln(tStructure,item_templateStruc[x]);
    end;

  Readln(tStructure);

  for x := 0 to 80 do
    begin
      Readln(tStructure,NpcTextStruc[x]);
    end;

  Readln(tStructure);

  for x := 0 to 2 do
    begin
      Readln(tStructure,PageTextStruc[x]);
    end;

  CloseFile(tStructure);

end;
//-------------------------------------------------------------------

end.
