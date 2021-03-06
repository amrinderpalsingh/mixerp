﻿using MixERP.Net.Common.Base;
using System;
using System.Drawing.Imaging;
using System.Web.Hosting;

namespace MixERP.Net.HtmlParser.ImageSerializer
{
    public class HtmlImageSerializer : IHtmlImageSerializer
    {
        public string TempDirectory { get; set; }

        public string Html { get; set; }

        public ImageFormat ImageFormat { get; set; }

        public event EventHandler<ImageSavedEventArgs> ImageSaved;

        public void Serialize()
        {
            if (this.TempDirectory == null)
            {
                throw new MixERPException(Resources.Messages.TempDirectoryNullError);
            }

            string imagePath = HostingEnvironment.MapPath(this.TempDirectory + Guid.NewGuid());

            if (string.IsNullOrWhiteSpace(imagePath))
            {
                throw new MixERPException(Resources.Messages.CouldNotDetermineVirtualPathError);
            }

            this.CreateImage(imagePath);
        }

        internal virtual void CreateImage(string imagePath)
        {
        }

        public void OnImageSaved(ImageSavedEventArgs e)
        {
            if (this.ImageSaved != null)
            {
                this.ImageSaved(this, e);
            }
        }
    }
}