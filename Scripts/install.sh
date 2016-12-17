#! /bin/sh

echo 'Downloading from http://download.unity3d.com/download_unity/38b4efef76f0/MacEditorInstaller/Unity-5.5.0f3.pkg: '
curl -o Unity.pkg http://download.unity3d.com/download_unity/38b4efef76f0/MacEditorInstaller/Unity-5.5.0f3.pkg


echo 'Downloading from http://download.unity3d.com/download_unity/38b4efef76f0/MacEditorTargetInstaller/UnitySetup-Windows-Support-for-Editor-5.5.0f3.pkg'
curl -o UnityWindowsSupport.pkg http://download.unity3d.com/download_unity/38b4efef76f0/MacEditorTargetInstaller/UnitySetup-Windows-Support-for-Editor-5.5.0f3.pkg

echo 'Downloading from http://download.unity3d.com/download_unity/38b4efef76f0/MacEditorTargetInstaller/UnitySetup-Linux-Support-for-Editor-5.5.0f3.pkg'
curl -o UnityLinuxSupport.pkg http://download.unity3d.com/download_unity/38b4efef76f0/MacEditorTargetInstaller/UnitySetup-Linux-Support-for-Editor-5.5.0f3.pkg

echo 'Installing Unity.pkg'
sudo installer -dumplog -package Unity.pkg -target /

echo 'Installing UnityWindowsSupport.pkg'
sudo installer -dumplog -package UnityWindowsSupport.pkg -target /

echo 'Installing UnityLinuxSupport.pkg'
sudo installer -dumplog -package UnityLinuxSupport.pkg -target /
