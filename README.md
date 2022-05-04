# Xamarin android background service
1. Main Page에서 Start service message를 보낸다. > Main Activity에서 구독하고 StartService
2. 서비스: Service Message를 보낸다. > Main Page에서 구독하고 Message를 표시 및 DB저장
3. StartService() > Service.OnCreate() > Service.OnStartCommand()

