BRT Table
========================


Scanning and Keystoning: both take place inside their respective parent objects, `ScannerScheme` and `ProjectorsScheme`.

Scanning
---------------

Scanning's most important functionalities are in `Scanners.cs`, attached to the `CameraKeystoned` GameObject.

The grid's dimensions are defined by the two public variables
```
public int _numOfScannersX;
public int _numOfScannersY;
```

The Scanner object receives the modified texture from a keystoned quad `GameObject` in `assignRenderTexture ();`. This keystoned quad has a `RenderTexture` assigned to it via another, orthogonal camera looking at the camera's stream, the `KeystoneCamera` `GameObject`. This camera has its Target Texture set to the keystoned quad `GameObject`.

In order for scanning to work, the `KeystoneCamera` has to look down at the webcam's stream, with the scanning grid's parent object vertically above the camera and the keystoned quad.

The grid is attached to the `ScanGridParent GameObject`, and it gets population upon play.

Keystoning
---------------

Keystoning takes place in two separate instances of `keyStone.cs`, one attached to `ScannerScheme` and another one to `ProjectorsScheme`. 

Agents
---------------

