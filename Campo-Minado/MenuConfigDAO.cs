﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Campo_Minado
{
    internal class MenuConfigDAO
    {

        private string path = $"{System.Environment.CurrentDirectory}\\Config.txt";
        public MenuConfigDAO() 
        { }

        public void GravarConfig(List<MenuConfig> lista)
        {
                
            try
            {
                File.WriteAllText(path, Criptografar.StringEncodeBase64(Newtonsoft.Json.JsonConvert.SerializeObject(lista)));
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Erro {ex}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public List<MenuConfig> GetMenuConfigs()
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<MenuConfig>>(Criptografar.StringDecodeBase64(File.ReadAllText(path)));
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Erro {ex}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);

                return new List<MenuConfig>();
            }
        }

    }
}