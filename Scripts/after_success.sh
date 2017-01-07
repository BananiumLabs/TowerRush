#! /bin/sh

echo "Build Success! Sending Notification Message. Please Wait"
curl -s --user 'api:key-2216f9d7fc3e654fce523dd3d56d21c6' \
    https://api.mailgun.net/v3/m.enumc.com/messages \
    -F from='API Travis <api@m.enumc.com>' \
    -F to='2TBS Developers <admin@fewdpew.me>' \
    -F subject='TowerRush Build Succeeded - Travis CI' \
    -F text='Travis build Succeeded. This is a notification message. No reply.' 
echo "Curl request sent!"
