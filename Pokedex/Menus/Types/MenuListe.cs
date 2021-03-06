﻿using Pokedex.Utils;
using System;
using System.Threading.Tasks;

namespace Pokedex.Menus.Instances
{
    public abstract class MenuListe<T> : Menu
    {

        protected static int MAX_PER_PAGE = 10;

        private int index = 0;
        private int row = 0;
        private T[] items;
        private bool IsLoadingData;

        public MenuListe() : base("Liste de " + typeof(T).Name)
        {
            this.items = new T[MAX_PER_PAGE];
            LoadData();
        }

        public void SetData(T[] data) => this.items = data;

        public void LoadData()
        {
            this.IsLoadingData = true;
            Task.Run(() =>
            {
                this.items = new T[MAX_PER_PAGE];
                for (int i = 0; i < MAX_PER_PAGE; i++)
                    items[i] = GetData(index * MAX_PER_PAGE + i);
                this.IsLoadingData = false;
                RequestRefresh();
            });
        }

        public abstract T GetData(int index);

        public override void Run()
        {
            if(IsLoadingData)
            {
                ColorConsole.WriteLine("   Chargement des données en cours...", ConsoleColor.White);
            } 
            else
            {
                for(int i = 0; i < items.Length; i++)
                {
                    T item = items[i];
                    Console.ForegroundColor = row == i ? ConsoleColor.Cyan : ConsoleColor.White;
                    Console.WriteLine("   " + (Equals(item, default(T)) ? "Donnée introuvable." : item.ToString()));
                    Console.ResetColor();
                }
            }

            Console.WriteLine(" ");
            ColorConsole.WriteLine("─────────── COMMANDES ───────────", ConsoleColor.White);
            ColorConsole.WriteLine("    ←    ", "Page precedente", ConsoleColor.Yellow, ConsoleColor.White);
            ColorConsole.WriteLine("    →    ", "Page suivante", ConsoleColor.Yellow, ConsoleColor.White);
            ColorConsole.WriteLine("    ↑    ", typeof(T).Name + " precedent", ConsoleColor.Yellow, ConsoleColor.White);
            ColorConsole.WriteLine("    ↓    ", typeof(T).Name + " suivant", ConsoleColor.Yellow, ConsoleColor.White);
            ColorConsole.WriteLine("  ENTER  ", "Acceder au details du " + typeof(T).Name + " selectionné", ConsoleColor.Yellow, ConsoleColor.White);
            ColorConsole.WriteLine("SPACEBAR ", "Retour au menu principal", ConsoleColor.Yellow, ConsoleColor.White);

        }

        public override void ApplyKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if (index > 0 && !this.IsLoadingData && !IsDisplaying)
                    {
                        index--;
                        LoadData();
                    }
                        
                    break;
                case ConsoleKey.RightArrow:
                    if (!this.IsLoadingData && !IsDisplaying)
                    {
                        index++;
                        LoadData();
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (row > 0)
                        row--;
                    break;
                case ConsoleKey.DownArrow:
                    if (row < MAX_PER_PAGE - 1)
                        row++;
                    break;
                case ConsoleKey.Enter:
                    T item = items[row];
                    if(!object.Equals(item, default(T)))
                        Pokedex.CURRENT_MENU = new MenuInformations<T>(item, this);
                    break;
                case ConsoleKey.Spacebar:
                    Pokedex.CURRENT_MENU = MenuManager.FromType<MenuPrincipal>();
                    break;
            }
        }

    }
}
