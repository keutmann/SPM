/*
$Revision:$
$GlobalRev:$
$Author:$
$LastChangedDate:$

 * Review by Keutmann 11 feb 2007
 * I have implementet SelectedLanguage property and some private members, 
 * to show how I think it should be.
 * This is to handle the language selection and not to create a new ResourceManager 
 * and GlobalInfo every time a translated text is needed.
 * The Property also handles the Registry.
 * All the review code have been comment out and no other code have been change to support this code.
 * I will recommend using the property "SelectedLanguage" and change the menu selection code to support it.
 * 
 * I usally do not use Type before the variables (only in javascript). The reason is that C# is a strongly type language and
 * and it makes code harder to read. 
 * So the const string should look like this :
 * 
 * public const string REGKEY_CULTURE = "Culture";
 * 
 * Code change by keutmann 18 april 2007
 * I have implementet the above review.
 * 
 * 
*/
using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using SPM2.Framework.IoC;

//using Keutmann.SharePointManager.Library;

namespace Keutmann.SharePointManager.Library
{

    [IoCLifetime(Singleton=true)]
    public class SPMLocalization : ISPMLocalization
    {
        public const string C_REGKEY_CULTURE = "Culture";
        public const string C_REGKEY_CULTUREID = "CultureID";

        public const string C_CULTURE_EN = "EN";
        public const string C_CULTURE_ES = "ES";
        public const string C_CULTURE_NL = "NL";
        public const string C_CULTURE_SV = "SV";

        
        private static CultureInfo _selectedCulture = null;
        private static string _selectedLanguage = null;
        private static ResourceManager _formResources = null;


        public static ResourceManager FormResources
        {
            get
            {
                if (_formResources == null)
                {
                    _formResources = new ResourceManager("Keutmann.SharePointManager.SPManagerLanguage", Assembly.GetExecutingAssembly());
                }
                return _formResources;
            }
        }

        public static string SelectedLanguage
        {
            get
            {
                if (_selectedLanguage == null)
                {
                    //_selectedLanguage = SPMRegistry.GetValue(C_REGKEY_CULTURE, C_REGKEY_CULTUREID) as string;
                    if (_selectedLanguage == null)
                    {
                        _selectedLanguage = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
                    }
                    _selectedCulture = CultureInfo.CreateSpecificCulture(_selectedLanguage);
                }
                return _selectedLanguage;
            }
            set
            {
                _selectedLanguage = value;
                _selectedCulture = CultureInfo.CreateSpecificCulture(_selectedLanguage);
                //SPMRegistry.SetValue(SPMLocalization.C_REGKEY_CULTURE, SPMLocalization.C_REGKEY_CULTUREID, _selectedLanguage);
            }
        }


        public static CultureInfo SelectedCulture
        {
            get
            {
                if (_selectedCulture == null)
                {
                     _selectedCulture = CultureInfo.CreateSpecificCulture(SelectedLanguage);
                }
                return _selectedCulture;

            }
        }


        public static string GetString(string word)
        {
            var result = FormResources.GetString(word, SelectedCulture);
            //if(result != null)
                return result;
            //return word;
        }

        public string GetText(string word)
        {
            return GetString(word);
        }

        //public static CultureInfo SelectedLanguage()
        //{
        //    CultureInfo myCulture = CultureInfo.CreateSpecificCulture((string)SPMRegistry.GetValue(C_REGKEY_CULTURE, C_REGKEY_CULTUREID));
        //    return myCulture;
        //}

        //public static string GetString(string Word)
        //{
        //    CultureInfo myCulture = SelectedLanguage();
        //    ResourceManager FormResources = new ResourceManager("Keutmann.SharePointManager.SPManagerLanguage", Assembly.GetExecutingAssembly());
        //    string strReturn = FormResources.GetString(Word, myCulture);
        //    return strReturn;
        //}
	}
}
