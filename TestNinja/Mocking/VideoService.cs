﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        //For Dependency Injection via Constructor
        public IFileReader _fileReader { get; set; }
        public IVideoRepository _videoRepository;

        //This way of injecting dependency is called
        // Poor's man dependency injection
        public VideoService(IFileReader filereader = null, IVideoRepository videoRepository = null)
        {
            _fileReader = filereader ?? new FileReader();
            _videoRepository = videoRepository ?? new VideoRepository();
        }


        //For Dependency Injection via Property
        //public IFileReader FileReader { get; set; }


        //For Dependency Injection via Property
        //public VideoService()
        //{
        //    FileReader = new FileReader();
        //}

        //public string ReadVideoTitleInjectionViaProperty()
        //{
        //    var str = FileReader.Read("video.txt");
        //    var video = JsonConvert.DeserializeObject<Video>(str);
        //    if (video == null)
        //        return "Error parsing the video.";
        //    return video.Title;
        //}

        public string ReadVideoTitleDependencyInjectionViaMethodParameter(IFileReader fileReader)
        {
            var str = fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string ReadVideoTitleDependencyInjectionViaConstructor()
        {
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();

            var videos = _videoRepository.GetUnprocessedVideos();

            foreach (var v in videos)
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}