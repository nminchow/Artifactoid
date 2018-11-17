using System;
using System.Collections.Generic;
using System.Text;

namespace Artifact.Models.CardInterfaces
{
    class Methods
    {
        public static string InLanguage(Languages language, ILanguageable type)
        {
            switch (language)
            {
                case Languages.english: return type.english;
                case Languages.german: return type.german;
                case Languages.french: return type.french;
                case Languages.italian: return type.italian;
                case Languages.koreana: return type.koreana;
                case Languages.spanish: return type.spanish;
                case Languages.schinese: return type.schinese;
                case Languages.tchinese: return type.tchinese;
                case Languages.russian: return type.russian;
                case Languages.thai: return type.thai;
                case Languages.japanese: return type.japanese;
                case Languages.portuguese: return type.portuguese;
                case Languages.polish: return type.polish;
                case Languages.danish: return type.danish;
                case Languages.dutch: return type.dutch;
                case Languages.finnish: return type.finnish;
                case Languages.norwegian: return type.norwegian;
                case Languages.swedish: return type.swedish;
                case Languages.hungarian: return type.hungarian;
                case Languages.czech: return type.czech;
                case Languages.romanian: return type.romanian;
                case Languages.turkish: return type.turkish;
                case Languages.brazilian: return type.brazilian;
                case Languages.bulgarian: return type.bulgarian;
                case Languages.greek: return type.greek;
                case Languages.ukrainian: return type.ukrainian;
                case Languages.latam: return type.latam;
                case Languages.vietnamese: return type.vietnamese;
                default: return type.english;
            }
        }
    }
    

    interface ILanguageable
    {
        string english { get; set; }
        string german { get; set; }
        string french { get; set; }
        string italian { get; set; }
        string koreana { get; set; }
        string spanish { get; set; }
        string schinese { get; set; }
        string tchinese { get; set; }
        string russian { get; set; }
        string thai { get; set; }
        string japanese { get; set; }
        string portuguese { get; set; }
        string polish { get; set; }
        string danish { get; set; }
        string dutch { get; set; }
        string finnish { get; set; }
        string norwegian { get; set; }
        string swedish { get; set; }
        string hungarian { get; set; }
        string czech { get; set; }
        string romanian { get; set; }
        string turkish { get; set; }
        string brazilian { get; set; }
        string bulgarian { get; set; }
        string greek { get; set; }
        string ukrainian { get; set; }
        string latam { get; set; }
        string vietnamese { get; set; }

        string InLanguage(Languages language);
    }
}
