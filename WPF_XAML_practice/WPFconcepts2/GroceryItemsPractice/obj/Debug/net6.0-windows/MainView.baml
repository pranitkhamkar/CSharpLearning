   M S B A M L   `   `   `  ????O  KGroceryItemsPractice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:GroceryItemsPracticeGroceryItemsPractice  5   	   #    GroceryItemsPractice.MainView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:GroceryItemsPractice     5   	     ? Title$  Grocery Items View??5   	   $	??450??6$   $	??800??61   .??5	      ? $??50q?6    ? RowDefinitions 5
      ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $??* ?6   .+?5      ?? $*??$Welcome To Grocery Items Application??6   $??25(?5      
?????d?$
??Bold"?5      $??0??5      ?? 5       ?? Orientation$ 
Horizontal=?6   $
??0 10q?5      $??1??5      $??Right=?5      .+?5      ?? $
??Edit??5      $??0 0 10 0q?5      $??Right=?5      
???   ?
????+??$??70??5       ??5      ?? *EditCommand+5       ?? 5!      $??Delete??5"      $??Right=?5#      
???   ?
????+??$??0 0 10 0q?5&      $??70??5'      ??5!      ?? *DeleteCommand+5'      ?? 5(      $	??Add??5)      $??Right=?5*      
???   ?
????+??$??70??5-      ??5(      ?? *AddGroceryItemCommand+5-      5.      &   System.Windows.Controls.DataGrid  5/         SelectionMode$ Single=?51         CanUserAddRows$ False??52      $??2??53      ??5/      ?? *GroceryItemList+ ?? SelectedItem 50      ?? *SelectedGroceryItem+53      54      55      