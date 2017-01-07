#! /bin/sh

echo "Build Failed! Sending Notification Message. Please Wait"
curl -s --user 'api:key-2216f9d7fc3e654fce523dd3d56d21c6' \
    https://api.mailgun.net/v3/m.enumc.com/messages \
    -F from='API Travis <api@m.enumc.com>' \
    -F to='2TBS Developers <eric@enumc.com>' \
    -F subject='TowerRush Build Failed - Travis CI' \
    -F text='Travis build failed. This is a notification message. No reply.' 
echo "Curl request sent!"
