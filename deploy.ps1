# Cấu hình
$websiteName = "techwiz-btbk"
$sourceCodePath = "C:\inetpub\wwwroot\techwiz-btbk\be\PlantNest"

# Di chuyển đến thư mục chứa mã nguồn
Set-Location $sourceCodePath

# Pull mã nguồn mới từ nhánh main
git pull origin main

# Tắt website trên IIS
Stop-WebSite -Name $websiteName

# Triển khai ứng dụng
dotnet publish -c Release -o bin

# Bật website trên IIS
Start-WebSite -Name $websiteName
