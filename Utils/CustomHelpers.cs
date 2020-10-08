using ASP_ComplexEx.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ASP_ComplexEx.Utils
{
    public static class CustomHelpers
    {
        public static MvcHtmlString EditBlockPrint(this HtmlHelper html, string label, string input, string imgPath)
        {
            TagBuilder builder = new TagBuilder("div");
            builder.Attributes.Add("class", "parameter form__parameter");
            TagBuilder image = new TagBuilder("img");
            image.Attributes.Add("src", imgPath);
            image.Attributes.Add("class", "form__image");
            image.Attributes.Add("height", "50px");
            builder.InnerHtml += image.ToString();

            TagBuilder paramDesc = new TagBuilder("div");
            paramDesc.Attributes.Add("class", "clmn");

            
            paramDesc.InnerHtml += html.LabelForModel("label").ToString();
            paramDesc.InnerHtml += input;

            builder.InnerHtml += paramDesc.ToString();
            return new MvcHtmlString(builder.ToString());
        }
        public static MvcHtmlString ParameterBlockPrint(this HtmlHelper html, string imgPath, string parameterHeader, string obj)
        {
            //
            TagBuilder builder = new TagBuilder("div");
            builder.Attributes.Add("class", "rooms__parameters");
            TagBuilder img = new TagBuilder("img");
            img.Attributes.Add("class", "image");
            img.Attributes.Add("src", imgPath);
            builder.InnerHtml = img.ToString();

            TagBuilder parametersBlock = new TagBuilder("div");
            parametersBlock.Attributes.Add("class", "rooms__info");

            TagBuilder header = new TagBuilder("p");
            header.SetInnerText(parameterHeader+":");
            TagBuilder value = new TagBuilder("p");
            value.SetInnerText(obj);

            parametersBlock.InnerHtml = header.ToString();
            parametersBlock.InnerHtml += value.ToString();

            builder.InnerHtml += parametersBlock.ToString();
            return new MvcHtmlString(builder.ToString());
            //
        }

        public static MvcHtmlString RoomPrint(this HtmlHelper html, Room room, bool isAdmin)
        {
            TagBuilder builder = new TagBuilder("a");
            builder.Attributes.Add("class", "item rooms__item");
            builder.Attributes.Add("href", $"/Home/SelectedRoom/{room.Id}");
            builder.Attributes.Add("style", "background-image:url("+room.Images.FirstOrDefault(i=>i.IsLogo).Path+")");
            TagBuilder hover = new TagBuilder("div");
            hover.Attributes.Add("class", "rooms__hover");

            TagBuilder firstBlock = new TagBuilder("div");
            firstBlock.Attributes.Add("class", "additional rooms__additional");
            firstBlock.InnerHtml += html.ParameterBlockPrint("/Images/thinking.svg", "DIFFICULTY", room.DifficultyLevel.ToString());
            firstBlock.InnerHtml += html.ParameterBlockPrint("/Images/fear.svg", "CREEPINESS", room.FearLevel.ToString());
            firstBlock.InnerHtml += html.ParameterBlockPrint("/Images/export.svg", "ESCAPE RATE", room.Rating.ToString() + "%");

            hover.InnerHtml += firstBlock.ToString();
            TagBuilder secondBlock = new TagBuilder("div");
            secondBlock.Attributes.Add("class", "primary rooms__primary");

            TagBuilder title = new TagBuilder("p");
            title.Attributes.Add("class", "rooms__title");
            title.SetInnerText(room.Title);
            secondBlock.InnerHtml += title.ToString();

            TagBuilder info = new TagBuilder("div");
            info.Attributes.Add("class", "clmn");
            info.InnerHtml += html.ParameterBlockPrint("/Images/team.svg", "GROUP SIZE", room.MinPlayers.ToString() + "-" + room.MaxPlayers.ToString() + " PPL");
            info.InnerHtml += html.ParameterBlockPrint("/Images/clock.svg", "TIME LIMIT", room.Duration.ToString() + " MINS");
            secondBlock.InnerHtml += info.ToString();
            hover.InnerHtml += secondBlock.ToString();
            builder.InnerHtml += hover.ToString();

            if (isAdmin)
            {
                builder.Attributes.Remove("style");
                builder.Attributes.Add("style", $"background-image:url({room.Images.Where(i => i.IsLogo == true).First().Path}); width: 100%; margin: 0; border-radius: 0; " +
                    $"border-top-left-radius: 10px; border-top-right-radius: 10px;");
            }
            return new MvcHtmlString(builder.ToString());
        }

        public static MvcHtmlString GalleryPrint(this HtmlHelper html, List<ImageForRoom> images)
        {
            TagBuilder builder = new TagBuilder("div");
            builder.Attributes.Add("class", "fotorama fotorama-border");
            foreach (ImageForRoom image in images)
            {
                TagBuilder img = new TagBuilder("img");
                img.Attributes.Add("src", image.Path);
                builder.InnerHtml += img.ToString();
            }
            return new MvcHtmlString(builder.ToString());
        }
    }
}