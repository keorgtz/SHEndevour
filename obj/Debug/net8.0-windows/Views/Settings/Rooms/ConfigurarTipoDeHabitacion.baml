   M S B A M L   `   `   `  ����E  ASHEndevour, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:SHEndevour.Views.Settings.RoomsSHEndevour.Views.Settings.Rooms  5      [2clr-namespace:SHEndevour.ViewModels.Settings.Rooms$SHEndevour.ViewModels.Settings.Rooms  5      @    :SHEndevour.Views.Settings.Rooms.ConfigurarTipoDeHabitacion   5      a ]DevExpress.Xpf.Core.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:SHEndevour.Views.Settings.Rooms     5      c _MaterialDesignThemes.MahApps, Version=3.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_	 [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  	 5      =vm2clr-namespace:SHEndevour.ViewModels.Settings.Rooms  	 5      ���#f1f1f1  � DataContext  5      F   @SHEndevour.ViewModels.Settings.Rooms.RoomTypeManagementViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#   .+�5!      ( 	 "MaterialDesignThemes.Wpf.ColorZone  $��10q�6'   . 	 (MaterialDesignThemes.Wpf.ElevationAssist   	Elevation$	 Dp4=�5"      $}�False��5#         CornerRadius$ 5��5$      
�������   Mode$ Custom=�5&      $
��Left=�5'      . 	 (MaterialDesignThemes.Wpf.ColorZoneAssist   
Background �#022534.��5*      �� $��0��6    �� Orientation$ 
Horizontal=�6-   .+�5,      �� $��7q�5-      $��0,0,5,0q�6)   
����iA�   MaterialDesignFlatButton#��[  5.      ��5,      �� *AddRoomTypeCommand+.��5/      �� $ 
Horizontal=�6%   .+�50      ' 	 !MaterialDesignThemes.Wpf.PackIcon  $��2q�66      Kind$	 Add=�6A   �� 51      $��
Crear Tipo��6(   52      53      �� 55      $��7q�56      $��0,0,5,0q�6)   
����� �#��[  57      ��55      �� *ViewRoomTypeCommand+.��58      �� $ 
Horizontal=�6%   .+�59        $��2q�66   $
 Edit=�6A   �� 5:      $��Examinar Tipo��6(   5;      5<      �� 5>      $��7q�5?      $��0,0,5,0q�6)   
���  ��#��[  5@      ��5>      �� *DeleteRoomTypeCommand+.��5A      �� $ 
Horizontal=�6%   .+�5B        $��2q�66   $ Remove=�6A   �� 5C      $��Eliminar Tipo��6(   5D      5E      5G      5H      5L      &   System.Windows.Controls.DataGrid  5O      -   5        	  Name$	 RoomTypeDataGrid��5R      $��1��5O      
   AutoGenerateColumns$
 False��5Q         SelectionMode$ Single=�5S         CanUserAddRows$ False��5T         SelectionUnit$ FullRow=�5U      $��10q�5W      * 	 $MaterialDesignThemes.Wpf.ThemeAssist   Theme$ Light=�5X      $	 Dp8=�5Y        MaterialDesignDataGrid#��[ 5Z      ��5P      �� *	RoomTypes+ �� SelectedItem 5V      �� *SelectedRoomType+   Columns 5\      0  *System.Windows.Controls.DataGridTextColumn  5]      ,	  &System.Windows.Controls.DataGridColumn 	  Header$
 Tipo��6F    	  
IsReadOnly$
 True��6T   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6%   �� *RoomTypeKey+6T     5^      $ Descripcion��6E   $
 True��6Z    6%   �� *Description+6Z     5_      $ Sencilla��6U   $
 True��6g    6%   �� *
SingleRate+ �� StringFormat$ N2��6g     5`      $ SencillaMin��6X   $
 True��6m    6%   �� *MinSingleRate+$ N2��6m     5a      $ Doble��6U   $
 True��6d    6%   �� *
DoubleRate+$ N2��6d     5b      $ DobleMin��6X   $
 True��6j    6%   �� *MinDoubleRate+$ N2��6j     5c      $ Triple��6U   $
 True��6e    6%   �� *
TripleRate+$ N2��6e     5d      $ 	TripleMin��6X   $
 True��6k    6%   �� *MinTripleRate+$ N2��6k     5e      $ 	Quadruple��6X   $
 True��6k    6%   �� *QuadrupleRate+$ N2��6k     5f      $ QuadrupleMin��6[   $
 True��6q    6%   �� *MinQuadrupleRate+$ N2��6q   5h      5j      5k      