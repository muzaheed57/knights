//-----------------------------------------------------------------------------
// Copyright (c) 2012 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------

exec("./playGui.gui");

GlobalActionMap.bind("keyboard", "escape", "quit");

//-----------------------------------------------------------------------------
// The knights.

datablock PlayerData(Knight) {
   shapeFile = "./knight.dts";
};

singleton Material(KnightMaterial) {
   diffuseColor[0] = "1 0 0";
   mapTo = "PlayerTexture";
};

new ActionMap(KnightSelectMap);

function Knight::onAdd(%this, %knight) {
   if(%knight.selectKey !$= "") {
      KnightSelectMap.bindCmd("keyboard", %knight.selectKey, "selectKnight(" @ %knight @ ");");
   }
}

function Knight::onRemove(%this, %knight) {
   if(%knight.selectKey !$= "") {
      KnightSelectMap.unbind("keyboard", %knight.selectKey);
   }
}

function selectKnight(%knight) {
   echo("Knight selected:" SPC %knight.name);
}

//-----------------------------------------------------------------------------
// Client and camera.

datablock CameraData(Observer) {};

function GameConnection::onEnterGame(%client) {
   new Camera(TheCamera) {
      datablock = Observer;
   };
   TheCamera.setTransform("0 0 2 1 0 0 0");
   TheCamera.scopeToClient(%client);
   %client.setControlObject(TheCamera);
   GameGroup.add(TheCamera);
   Canvas.setContent(PlayGui);
   activateDirectInput();
   KnightSelectMap.push();
}

//-----------------------------------------------------------------------------
// Game.

singleton Material(BlankWhite) {
   detailMap[0] = "./cross";
   detailScale[0] = "20 20";
};

function onStart() {
   new SimGroup(GameGroup) {
      new LevelInfo(TheLevelInfo) {
         canvasClearColor = "0 0 0";
      };
      new GroundPlane(TheGround) {
         position = "0 0 0";
         material = BlankWhite;
      };
      new Sun(TheSun) {
         azimuth = 230;
         elevation = 70;
         color = "1 1 1";
         ambient = "0.1 0.1 0.1";
         castShadows = true;
      };

      new SimGroup(Knights) {
         new AIPlayer(SerQuentin) {
            datablock = Knight;
            position = "-3 5 1";
            selectKey = "q";
         };
         new AIPlayer(SerJordan) {
            datablock = Knight;
            position = "-1 5 1";
            selectKey = "j";
         };
         new AIPlayer(SerVermare) {
            datablock = Knight;
            position = "1 5 1";
            selectKey = "v";
         };
         new AIPlayer(SerOrton) {
            datablock = Knight;
            position = "3 5 1";
            selectKey = "o";
         };
      };
   };
}

function onExit() {
   GameGroup.delete();
   ServerConnection.delete();
   ServerGroup.delete();
   KnightSelectMap.delete();
   deleteDataBlocks();
}
