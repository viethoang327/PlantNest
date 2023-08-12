# Cấu hình
$websiteName = "techwiz_btbk"
$sourceCodePath = "C:\inetpub\wwwroot\techwiz-btbk\be\PlantNest"

# Di chuyển đến thư mục chứa mã nguồn
Set-Location $sourceCodePath

# Pull mã nguồn mới từ nhánh main
git pull origin main

# Tắt website trên IIS
Stop-WebSite -Name $websiteName
if ($?) {
    Write-Host "Tắt IIS thành công." -ForegroundColor Green
} else {
    Write-Host "Lỗi khi tắt IIS." -ForegroundColor Red
    exit
}

# Triển khai ứng dụng
dotnet publish
if ($?) {
    Write-Host "Triển khai ứng dụng thành công." -ForegroundColor Green
} else {
    Write-Host "Lỗi khi triển khai ứng dụng." -ForegroundColor Red
    exit
}

# Bật website trên IIS
Start-WebSite -Name $websiteName
if ($?) {
    Write-Host "Bật IIS thành công." -ForegroundColor Green
} else {
    Write-Host "Lỗi khi bật IIS." -ForegroundColor Red
    exit
}

# Đợi 3 giây trước khi tắt script