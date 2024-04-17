
using MrJi.Example;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;


namespace MrJi
{
    /// <summary>
    /// ª∫¥Ê–≈œ¢
    /// </summary>
    public class View_Cache : IDisposable
    {
        string key = $"{Application.companyName}{Application.productName}".MD5();

        internal Cache m_Cache { set; get; } = null;

        [Preserve]
        public View_Cache()
        {
            string cacheString = PlayerPrefs.GetString(key);

            this.m_Cache = string.IsNullOrEmpty(cacheString) ? new Cache().Default() : cacheString.DESDecrypt().GetObject<Cache>();

            if (string.IsNullOrEmpty(cacheString)) SetCache();
        }


        private void SetCache()
        {
            PlayerPrefs.SetString(key,this.m_Cache.GetJson().DESEncrypt());
            PlayerPrefs.Save();
        }

        public void Dispose()
        {
            this.m_Cache = null;
        }


        #region Setting

        internal void Setting_BGMVolume()
        { 
           
        }

        internal void Setting_SpecialEfficacyVolume()
        {
        
        }
        internal void Setting_BGMIson(bool ison)
        {
            this.m_Cache.BGMIson = ison;
            SetCache();
        }

        #endregion
    }
}
