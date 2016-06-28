#! /bin/sh

echo 'Downloading from http://beta.unity3d.com/download/7633684eb4c7/MacEditorInstaller/Unity-5.4.0b22.pkg: '
curl -o Unity.pkg http://beta.unity3d.com/download/7633684eb4c7/MacEditorInstaller/Unity-5.4.0b22.pkg

echo 'Downloading from http://beta.unity3d.com/download/7633684eb4c7/MacEditorTargetInstaller/UnitySetup-Windows-Support-for-Editor-5.4.0b22.pkg'
curl -o UnityWindowsSupport.pkg http://beta.unity3d.com/download/7633684eb4c7/MacEditorTargetInstaller/UnitySetup-Windows-Support-for-Editor-5.4.0b22.pkg

echo 'Downloading from http://beta.unity3d.com/download/7633684eb4c7/MacEditorTargetInstaller/UnitySetup-Linux-Support-for-Editor-5.4.0b22.pkg'
curl -o UnityLinuxSupport.pkg http://beta.unity3d.com/download/7633684eb4c7/MacEditorTargetInstaller/UnitySetup-Linux-Support-for-Editor-5.4.0b22.pkg

echo 'Installing Unity.pkg'
sudo installer -dumplog -package Unity.pkg -target /

echo 'Installing UnityWindowsSupport.pkg'
sudo installer -dumplog -package UnityWindowsSupport.pkg -target /

echo 'Installing UnityLinuxSupport.pkg'
sudo installer -dumplog -package UnityLinuxSupport.pkg -target /
