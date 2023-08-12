using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace PlantNestApp.Controllers
{
	public class CICDController : Controller
	{
		[HttpPost]
		public async Task<IActionResult> DoRelease()
		{
			string wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
			string deployScriptPath = Path.Combine(wwwRootPath, "deploy.ps1");

			if (!System.IO.File.Exists(deployScriptPath))
			{
				return NotFound("Script not found");
			}

			ProcessStartInfo processInfo = new ProcessStartInfo
			{
				FileName = "powershell.exe", // Sử dụng PowerShell Core (pwsh) hoặc "powershell.exe" nếu bạn sử dụng PowerShell Windows
				Arguments = deployScriptPath,
				WorkingDirectory = wwwRootPath,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};

			using (Process process = new Process())
			{
				process.StartInfo = processInfo;
				process.Start();

				// Đợi quá trình kết thúc và lấy kết quả
				await process.WaitForExitAsync();
				string output = await process.StandardOutput.ReadToEndAsync();
				string error = await process.StandardError.ReadToEndAsync();

				if (process.ExitCode == 0)
				{
					return Ok("Deploy thành công");
				}
				else
				{
					return BadRequest($"Lỗi khi triển khai: {error}");
				}
			}
		}
	}
}
