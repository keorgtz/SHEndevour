   M S B A M L   `   `   `  ����E  ASHEndevour, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:SHEndevour.Views.Settings.RoomsSHEndevour.Views.Settings.Rooms  5      [2clr-namespace:SHEndevour.ViewModels.Settings.Rooms$SHEndevour.ViewModels.Settings.Rooms  5      :    4SHEndevour.Views.Settings.Rooms.ConfigurarHabitacion   5      a ]DevExpress.Xpf.Core.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:SHEndevour.Views.Settings.Rooms     5      c _MaterialDesignThemes.MahApps, Version=3.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_	 [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  	 5      =vm2clr-namespace:SHEndevour.ViewModels.Settings.Rooms  	 5      ���#F1F1F1  � DataContext  5      B   <SHEndevour.ViewModels.Settings.Rooms.RoomManagementViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#   .+�5#      ( 	 "MaterialDesignThemes.Wpf.ColorZone  $��10q�6'   . 	 (MaterialDesignThemes.Wpf.ElevationAssist   	Elevation$	 Dp4=�5$      $}�False��5%         CornerRadius$ 5��5&      
�������   Mode$ Custom=�5(      $
��Left=�5)      . 	 (MaterialDesignThemes.Wpf.ColorZoneAssist   
Background �#022534.��5,      �� $��0��6    �� Orientation$ 
Horizontal=�6-   .+�5.      �� $��7q�5/      $��0,0,5,0q�6)   
����iA�   MaterialDesignFlatButton#��[  50      ��5.      �� *AddRoomCommand+.��51      �� $ 
Horizontal=�6%   .+�52      ' 	 !MaterialDesignThemes.Wpf.PackIcon  $��2q�66      Kind$
 Plus=�6A   �� 53      $��Agregar��6(   54      55      �� 57      $��7q�58      $��0,0,5,0q�6)   
����� �#��[  59      ��57      �� *ViewRoomCommand+.��5:      �� $ 
Horizontal=�6%   .+�5;        $��2q�66   $
 Edit=�6A   �� 5<      $��	Ver Datos��6(   5=      5>      �� 5@      $��7q�5A      $��0,0,5,0q�6)   
���  ��#��[  5B      ��5@      �� *DeleteRoomCommand+.��5C      �� $ 
Horizontal=�6%   .+�5D        $��2q�66   $ Delete=�6A   �� 5E      $��Eliminar��6(   5F      5G      5I      5J      5P      &   System.Windows.Controls.DataGrid  5T   
   -   5        	  Name$	 RoomDataGrid��5W      $��1��5T      
   AutoGenerateColumns$
 False��5V         SelectionMode$ Single=�5X         CanUserAddRows$ False��5Y         SelectionUnit$ FullRow=�5Z      $��10q�5[      * 	 $MaterialDesignThemes.Wpf.ThemeAssist   Theme$ Light=�5]      $	 Dp8=�5^        MaterialDesignDataGrid#��[ 5_      ��5U      �� *Rooms+ �� SelectedItem 5\      �� *SelectedRoom+   Columns 5a      0  *System.Windows.Controls.DataGridTextColumn  5e      ,	  &System.Windows.Controls.DataGridColumn 	  Header$ ID��6%    	  
IsReadOnly$
 True��6H   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 61   �� *Id+6H     5f      $ Clave de Habitacion��6%   $
 True��6^    6B   �� *	RoomKey+6^     5g      $ Tipo de Habitacion��6%   $
 True��6j    6A   �� *RoomType.RoomTypeKey+6j     5h      $ Descripcion del Tipo��6%   $
 True��6l    6C   �� *RoomType.Description+6l     5i      $ Estado��6%   $
 True��6T    65   �� *
RoomStatus+6T   5k      5m      5n      