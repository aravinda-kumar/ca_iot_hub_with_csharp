﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTHubDeviceService
{
    public class Config
    {
        /// <summary>
        /// the ConnectionString
        /// </summary>
        public string ConnectionString { get; set; }
        public string HandleFileUploadNotificationUrl { get; internal set; }

        public static Config Read()
        {
            var filename = $"{typeof(Config).Assembly.GetName().Name}.exe.json";
            if (!File.Exists(filename)) return new IoTHubDeviceService.Config();
            var json = File.ReadAllText(filename);
            var config = JsonConvert.DeserializeObject<Config>(json);
            return config;
        }

        public void Write()
        {
            var json = JsonConvert.SerializeObject(this);
            var filename = $"{typeof(Config).Assembly.GetName().Name}.exe.json";
            File.WriteAllText(filename, json);
        }
    }
}
