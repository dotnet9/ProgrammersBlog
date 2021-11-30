using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using Entities.ComplexTypes;
using Entities.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ProgrammersBlog.Mvc.Helpers.Abstract;
using ProgrammersBlog.Shared.Utilities.Extensions;

namespace ProgrammersBlog.Mvc.Helpers.Concrete;

public class ImageHelper : IImageHelper
{
	private const string imgFolder = "img";
	private const string userImagesFolder = "userImages";
	private const string postImagesFolder = "postImages";
	private readonly IWebHostEnvironment _env;
	private readonly string _wwwroot;

	public ImageHelper(IWebHostEnvironment env)
	{
		_env = env;
		_wwwroot = _env.WebRootPath;
	}

	public async Task<IDataResult<ImageUploadedDto>> Upload(string name, IFormFile pictureFile, PictureType pictureType,
		string folderName = null)
	{
		folderName ??= pictureType == PictureType.User ? userImagesFolder : postImagesFolder;

		if (!Directory.Exists($"{_wwwroot}/{imgFolder}/{folderName}"))
			Directory.CreateDirectory($"{_wwwroot}/{imgFolder}/{folderName}");
		var oldFileName = Path.GetFileNameWithoutExtension(pictureFile.FileName);
		var fileExtension = Path.GetExtension(pictureFile.FileName);


		var regex = new Regex("[*'\",._&#^@]");
		name = regex.Replace(name, string.Empty);

		var dateTime = DateTime.Now;
		// AtillaKalay_587_5_38_12_3_10_2020.png
		var newFileName = $"{name}_{dateTime.FullDateAndTimeStringWithUnderscore()}{fileExtension}";
		var path = Path.Combine($"{_wwwroot}/{imgFolder}/{folderName}", newFileName);
		await using (var stream = new FileStream(path, FileMode.Create))
		{
			await pictureFile.CopyToAsync(stream);
		}

		var message = pictureType == PictureType.User
			? $"{name} 的图片已成功上传。"
			: $"{name} 文章图片已成功上传。";
		return new DataResult<ImageUploadedDto>(ResultStatus.Success, message, new ImageUploadedDto
		{
			FullName = $"{folderName}/{newFileName}",
			OldName = oldFileName,
			Extension = fileExtension,
			FolderName = folderName,
			Path = path,
			Size = pictureFile.Length
		});
	}

	public IDataResult<ImageDeletedDto> Delete(string pictureName)
	{
		var fileToDelete = Path.Combine($"{_wwwroot}/{imgFolder}/", pictureName);
		if (File.Exists(fileToDelete))
		{
			var fileInfo = new FileInfo(fileToDelete);
			var imageDeletedDto = new ImageDeletedDto
			{
				FullName = pictureName,
				Extension = fileInfo.Extension,
				Path = fileInfo.FullName,
				Size = fileInfo.Length
			};
			File.Delete(fileToDelete);
			return new DataResult<ImageDeletedDto>(ResultStatus.Success, imageDeletedDto);
		}

		return new DataResult<ImageDeletedDto>(ResultStatus.Error, "没有找到这样的图片。", null);
	}
}