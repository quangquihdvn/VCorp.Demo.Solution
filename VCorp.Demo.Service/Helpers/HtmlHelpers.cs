using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using VCorp.Demo.ViewModels.Common.JsonParse;
using static VCorp.Demo.Common.Constants.SystemConstants;

namespace VCorp.Demo.Service.Helpers
{
    public static class HtmlHelpers
    {
        public static List<dynamic> ConvertHtml(string body)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(body);
            var nodes = htmlDoc.DocumentNode.ChildNodes;
            var outputs = new List<dynamic>();

            var i = 1;
            foreach (var node in nodes)
            {
                var nodeObject = ConvertNode(node);
                if (nodeObject != null)
                {
                    outputs.Add(nodeObject);
                    nodeObject.Index = i;
                    i++;
                }
            }

            return outputs;
        }

        private static dynamic ConvertNode(HtmlNode htmlNode)
        {
            dynamic result = null;
            switch (htmlNode.Name)
            {
                case Node.P:
                case Node.H2:
                case Node.H3:
                    result = ConvertText(htmlNode);
                    break;
                case Node.Div:
                    var type = htmlNode.Attributes["Type"]?.Value.ToLower();
                    switch (type)
                    {
                        case DivType.TempWidgets:
                            result = ConvertTempWidget(htmlNode);
                            break;
                        case DivType.ProfileContentBox:
                            result = ConvertProfileContent(htmlNode);
                            break;
                        case DivType.SimpleQuote:
                            result = ConvertSimpleQuote(htmlNode);
                            break;
                        case DivType.Photo:
                            var classValue = htmlNode.Attributes["class"].Value;
                            if (classValue.Contains("GifPhoto"))
                            {
                                result = ConvertGif(htmlNode);
                            }
                            else
                            {
                                result = ConvertPhoto(htmlNode);
                            }
                            break;
                        case DivType.Content:
                            result = ConvertContent(htmlNode);
                            break;
                        case DivType.VideoStream:
                            result = ConvertVideo(htmlNode);
                            break;
                        case DivType.Hr:
                            result = ConvertHr();
                            break;
                        case DivType.LayoutAlbum:
                            result = ConvertLayoutAlbum(htmlNode);
                            break;
                        case DivType.Credit:
                            result = ConvertCredit(htmlNode);
                            break;
                    }
                    break;
                default:
                    break;

            }
            return result;
        }

        private static TextViewParse ConvertText(HtmlNode htmlNode)
        {
            if(htmlNode.Name == Node.P)
            {
                var allNode = htmlNode.Descendants();
                var removeNodes = htmlNode.ChildNodes.Where(x => x.Name == "span").ToList();
                foreach (var child in removeNodes)
                {
                    htmlNode.RemoveChild(child);
                }
            }
            var textViewModel = new TextViewParse
            {
                Type = htmlNode.Name,
                Value = htmlNode.Name == Node.P ? htmlNode.InnerHtml : htmlNode.InnerText,
            };
            return textViewModel;
        }

        private static PhotoParse ConvertPhoto(HtmlNode htmlNode)
        {
            var captionNode = htmlNode.ChildNodes.FirstOrDefault(x => x.Attributes.Any()
                                        && x.Attributes["class"]?.Value == "PhotoCMS_Caption");
            var firstDiv = htmlNode.ChildNodes.FirstOrDefault(x => x.Name == "div");
            var imgNode = firstDiv.ChildNodes.FirstOrDefault(x => x.Name == "a" || x.Name == "img");
            if (imgNode?.Name == "a")
            {
                imgNode = imgNode.ChildNodes.FirstOrDefault(x => x.Name == "img");
            }
            var result = new PhotoParse
            {
                Type = DivType.Photo,
                Image = new ImageParse
                {
                    Original_img = imgNode?.Attributes["data-original"].Value,
                    Src = imgNode?.Attributes["src"].Value,
                    Size = new ImageSizeParse
                    {
                        Width = Convert.ToInt32(imgNode?.Attributes["w"]?.Value),
                        Height = Convert.ToInt32(imgNode?.Attributes["h"]?.Value)
                    }
                },
                Caption = captionNode?.InnerText,
            };
            return result;
        }

        private static GifPhotoParse ConvertGif(HtmlNode htmlNode)
        {
            var captionNode = htmlNode.ChildNodes.FirstOrDefault(x => x.Attributes.Any() &&
                                                    x.Attributes["class"]?.Value == "PhotoCMS_Caption");
            //var image = htmlNode.FirstChild.FirstChild;
            var firstDiv = htmlNode.ChildNodes.FirstOrDefault(x => x.Name == "div");
            var imgNode = firstDiv.ChildNodes.FirstOrDefault(x => x.Name == "a" || x.Name == "img");
            if (imgNode?.Name == "a")
            {
                imgNode = imgNode.ChildNodes.FirstOrDefault(x => x.Name == "img");
            }
            var result = new GifPhotoParse
            {
                Type = DivType.GifPhoto,
                Filename = imgNode?.Attributes["src"]?.Value + ".mp4",
                Avatar = imgNode?.Attributes["src"]?.Value + ".png",
                Size = new ImageSizeParse
                {
                    Width = Convert.ToInt32(imgNode?.Attributes["w"]?.Value),
                    Height = Convert.ToInt32(imgNode?.Attributes["h"]?.Value)
                },
                Caption = captionNode?.InnerText,
            };
            return result;
        }

        private static ContentViewParse ConvertContent(HtmlNode htmlNode)
        {
            var divNode = htmlNode.FirstChild;
            var textViewModel = new ContentViewParse
            {
                Type = DivType.Content,
                Value = divNode.ChildNodes.Select(x => x.InnerText).ToArray(),
            };
            return textViewModel;
        }

        private static LayoutAlbumParse ConvertLayoutAlbum(HtmlNode htmlNode)
        {
            var rowImages = new List<TempwidgetsImageViewModel>();
            var caption = htmlNode.SelectSingleNode("//p[contains(@class,'LayoutAlbumCaption')]");
            var layoutAlbumRows = htmlNode.FirstChild.ChildNodes;
            var j = 1;
            foreach (var row in layoutAlbumRows)
            {
                var layoutAlbumItems = row.ChildNodes;
                var images = new List<TempwidgetsImageDetailModel>();
                foreach (var item in layoutAlbumItems)
                {
                    var aTag = item.ChildNodes["a"];
                    var img = aTag.ChildNodes["img"];
                    images.Add(
                        new TempwidgetsImageDetailModel
                        {
                            Src = img?.Attributes["src"]?.Value,
                            Original_img = aTag?.Attributes["href"]?.Value,
                            Size = new ImageSizeParse
                            {
                                Width = Convert.ToInt32(img?.Attributes["w"]?.Value),
                                Height = Convert.ToInt32(img?.Attributes["h"]?.Value)
                            }
                        });
                }
                rowImages.Add(new TempwidgetsImageViewModel
                {
                    Row = j,
                    Img = images
                });
                j++;
            }

            var tempWidgetsViewModel = new LayoutAlbumParse
            {
                Type = DivType.LayoutAlbum,
                Caption = caption?.InnerText,
                Img = rowImages
            };
            return tempWidgetsViewModel;
        }

        private static CreditParse ConvertCredit(HtmlNode htmlNode)
        {
            var itemViewModels = new List<ItemViewModel>();
            var creditItemNodes = htmlNode.FirstChild.SelectNodes("//div[@class='credit-item']");
            foreach (var creditItem in creditItemNodes)
            {
                var label = creditItem.ChildNodes["label"];
                var creditText = creditItem.ChildNodes["div"];
                itemViewModels.Add(new ItemViewModel
                {
                    Label = label.InnerText,
                    Text = creditText.InnerText.Trim()
                });
            }

            var publishDateTag = htmlNode.SelectSingleNode("//span[@class='publish-date']");
            var a = htmlNode.ChildNodes["a"];
            var creditViewModels = new CreditParse
            {
                Type = "credit",
                PublishDate = publishDateTag?.InnerText,
                Item = itemViewModels,
                Source = new SourceViewModel
                {
                    Url = a?.Attributes["href"]?.Value,
                    Text = a?.InnerText
                }
            };

            return creditViewModels;
        }

        private static HrParse ConvertHr()
        {
            return new HrParse
            {
                Type = "hr",
            };
        }

        private static VideoParse ConvertVideo(HtmlNode htmlNode)
        {
            var dataLayout = htmlNode.Attributes["data-layout"];
            var dataSrc = htmlNode.Attributes["data-src"];
            var dataVid = htmlNode.Attributes["data-vid"];
            var dataThumb = htmlNode.Attributes["data-thumb"];
            var caption = htmlNode.SelectSingleNode("//div[@class='VideoCMS_Caption']");
            var result = new VideoParse
            {
                Type = (dataLayout != null && dataLayout.Value == "square") ?
                "videoStreamSquare" : "videoStream",
                FileName = dataSrc != null ? dataSrc.Value : dataVid?.Value,
                Avatar = dataSrc != null ? dataSrc.Value : dataThumb?.Value,
                Caption = caption?.InnerText
            };
            return result;
        }

        private static SimpleQuoteParse ConvertSimpleQuote(HtmlNode htmlNode)
        {
            var childNodes = htmlNode.FirstChild.ChildNodes;
            var pQuote = childNodes.FirstOrDefault(x => x.Attributes["class"].Value == "quote");
            var starNameCaption = childNodes.FirstOrDefault(x => x.Attributes["class"].Value.Contains("StarNameCaption"));
            var result = new SimpleQuoteParse
            {
                Type = DivType.SimpleQuote,
                Quote = pQuote?.InnerText,
                StarNameCaption = starNameCaption.InnerText
            };
            return result;
        }

        private static ProfileContentBoxParse ConvertProfileContent(HtmlNode htmlNode)
        {
            var imgNode = htmlNode.FirstChild.ChildNodes["img"];
            var divNoe = htmlNode.FirstChild.ChildNodes["div"];
            var profileName = divNoe.ChildNodes.FirstOrDefault(x => x.Attributes["class"].Value == "NLProfileName");
            var profileMainInfo = divNoe.ChildNodes.FirstOrDefault(x => x.Attributes["class"].Value == "NLProfileMainInfo");

            var ulNode = htmlNode.ChildNodes[1].Element("ul");
            var profileInfo = ulNode.Elements("li").Select(x => x.InnerText).ToArray();
            var result = new ProfileContentBoxParse
            {
                Type = DivType.ProfileContentBox,
                Img = imgNode.Attributes["src"].Value,
                ProfileName = profileName?.InnerText,
                ProfileMainInfo = profileMainInfo?.InnerText,
                ProfileInfo = profileInfo
            };
            return result;
        }

        private static TempWidgetParse ConvertTempWidget(HtmlNode htmlNode)
        {
            var dataType = htmlNode.Attributes["data-type"].Value;
            var firstChild = htmlNode.ChildNodes.FirstOrDefault(x => x.Name == "div");
            var row = 1;
            var imgs = new List<TempwidgetsImageViewModel>();
            var rowNodes = firstChild.ChildNodes.Where(x => x.Name == "div");
            foreach (var childNote in rowNodes)
            {
                var aNodes = childNote.ChildNodes.SelectMany(x => x.ChildNodes).Where(x => x.Name == "a");
                var tempwidgetsImageDetailModels = new List<TempwidgetsImageDetailModel>();
                foreach (var aNode in aNodes)
                {
                    var imgNode = aNode.ChildNodes.First();
                    var width = imgNode.Attributes["data-width"];
                    var height = imgNode.Attributes["data-height"];
                    tempwidgetsImageDetailModels.Add(new TempwidgetsImageDetailModel
                    {
                        Original_img = aNode.Attributes["href"].Value,
                        Src = imgNode.Attributes["src"].Value,
                        Size = new ImageSizeParse
                        {
                            Width = width != null ? Convert.ToInt32(width.Value) : Convert.ToInt32(imgNode.Attributes["w"].Value),
                            Height = height != null ? Convert.ToInt32(height.Value) : Convert.ToInt32(imgNode.Attributes["h"].Value)
                        }
                    });
                }

                imgs.Add(new TempwidgetsImageViewModel
                {
                    Row = row,
                    Img = tempwidgetsImageDetailModels.Any() ?
                          tempwidgetsImageDetailModels : new List<TempwidgetsImageDetailModel> { new TempwidgetsImageDetailModel() }
                });
                row++;
            }
            var tempWidgetsViewModel = new TempWidgetParse
            {
                Type = dataType,
                Img = imgs
            };
            return tempWidgetsViewModel;
        }
    }
}
