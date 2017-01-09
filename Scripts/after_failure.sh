#! /bin/sh

echo "Build Failed! Sending Notification Message. Please Wait"
curl -s --user 'api:key-***REMOVED***' \
    https://api.mailgun.net/v3/m.enumc.com/messages \
    -F from='API Travis <api@m.enumc.com>' \
    -F to='2TBS Developers <admin@fewdpew.me>' \
    -F subject='TowerRush Build Failed - Travis CI' \
    -F text='Travis build failed. This is a notification message. No reply.' 
echo "Curl request sent!"
