﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using WebGrease;
using BeautyMe;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApi.Controllers
{
    public class ImagesController : ApiController
    {
        BeautyMeDBContext DB = new BeautyMeDBContext();
       Images images = new Images();
       

        [Route("api/uploadpicture")]
        public Task<HttpResponseMessage> Post()
        {
            string outputForNir = "start---";
            List<string> savedFilePath = new List<string>();
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            //Where to put the picture on server  ...MapPath("~/TargetDir")
            string rootPath = HttpContext.Current.Server.MapPath("~/uploadFile2");
            var provider = new MultipartFileStreamProvider(rootPath);
            var task = Request.Content.ReadAsMultipartAsync(provider).
                ContinueWith<HttpResponseMessage>(t =>
                {
                if (t.IsCanceled || t.IsFaulted)
                {
                    Request.CreateErrorResponse(HttpStatusCode.InternalServerError, t.Exception);
                }
                foreach (MultipartFileData item in provider.FileData)
                {
                    try
                    {
                        outputForNir += " ---here";
                        string name = item.Headers.ContentDisposition.FileName.Replace("\"", "");
                        outputForNir += " ---here2=" + name;

                        //need the guid because in react native in order to refresh an inamge it has to have a new name
                        //                          string newFileName = Path.GetFileNameWithoutExtension(name) + "_" + CreateDateTimeWithValidChars() + Path.GetExtension(name);
                        //string newFileName = images.CreateNewNameOrMakeItUniqe(Path.GetFileNameWithoutExtension(name)) + Path.GetExtension(name);

                        string newFileName = Path.GetFileNameWithoutExtension(name) + Path.GetExtension(name);
                            //string newFileName = name + "" + Guid.NewGuid();
                            outputForNir += " ---here3" + newFileName;
                            
                           // delete all files begining with the same name
                            string fileName = images.ImageFileExist(newFileName, rootPath);
                         
                            if (fileName != null)
                            {
                                File.Delete(fileName);
                            }


                            //File.Move(item.LocalFileName, Path.Combine(rootPath, newFileName));
                            File.Copy(item.LocalFileName, Path.Combine(rootPath, newFileName), true);
                            File.Delete(item.LocalFileName);
                            outputForNir += " ---here4";

                            Uri baseuri = new Uri(Request.RequestUri.AbsoluteUri.Replace(Request.RequestUri.PathAndQuery, string.Empty));
                            outputForNir += " ---here5";
                            string fileRelativePath = "~/uploadFile2/" + newFileName;
                            outputForNir += " ---here6 imageName=" + fileRelativePath;
                            Uri fileFullPath = new Uri(baseuri, VirtualPathUtility.ToAbsolute(fileRelativePath));
                            outputForNir += " ---here7" + fileFullPath.ToString();
                            savedFilePath.Add(fileFullPath.ToString());


                        }
                        catch (Exception ex)
                        {
                            outputForNir += " ---excption=" + ex.Message;
                            return Request.CreateResponse(HttpStatusCode.BadRequest, outputForNir);
                        }
                    }

                    return Request.CreateResponse(HttpStatusCode.Created, "nirchen " + savedFilePath[0] + "!" + provider.FileData.Count + "!" + outputForNir + ":)");
                });
            return task;
        }



    }


}