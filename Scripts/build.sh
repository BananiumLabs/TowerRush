#! /bin/sh

project="TowerRush"
projectWin="Windows"
projectMac="OS X"
projectLinux="Linux"
echo "Attempting to build $project for Windows"
echo $(pwd)
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath $(pwd) \
  -buildWindowsPlayer "$(pwd)/Build/windows/$projectWin.exe" \
  -quit

if [ $? -eq 0 ]
then
  echo "Windows Build Successful"
  break
else
  echo "Windows Build Failed" >&2
  exit 1
fi

echo "Attempting to build $project for OS X"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath $(pwd) \
  -buildOSXUniversalPlayer "$(pwd)/Build/osx/$projectMac.app" \
  -quit

if [ $? -eq 0 ]
then
  echo "Mac Build Successful"
  break
else
  echo "Mac Build Failed" >&2
  exit 1
fi

echo "Attempting to build $project for Linux"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath $(pwd) \
  -buildLinuxUniversalPlayer "$(pwd)/Build/linux/$projectLinux.exe" \
  -quit

if [ $? -eq 0 ]
then
  echo "Linux Build Successful"
  break
else
  echo "Linux Build Failed" >&2
  exit 1
fi

echo 'Logs from build'
cat $(pwd)/unity.log

if [ $? -eq 0 ]
then
  echo "Unity Log Printed"
  break
else
  echo "Unity Log Returned Error" >&2
  exit 1
fi
