   M S B A M L   `   `   `  ����E  ASHEndevour, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SHEndevour.ViewModelsSHEndevour.ViewModels  5   	   M+clr-namespace:SHEndevour.Views.DatabaseViewSHEndevour.Views.DatabaseView  5   	   4    .SHEndevour.Views.DatabaseView.DbConnectionView   5   	   a ]DevExpress.Xpf.Core.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _MaterialDesignThemes.MahApps, Version=3.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_	 [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  	 5   	   .vm#clr-namespace:SHEndevour.ViewModels  	 5   	   9local+clr-namespace:SHEndevour.Views.DatabaseView  	 5   	     � WindowStartupLocation$  CenterScreen=�5	       � 
ResizeMode$ NoResize=�6?    � WindowStyle$
 None=�6U   ���#2d2d2d � Title$ Endevour - Servidores��5   	   $	��370��6'   $	��550��64    � DataContext 5      1   +SHEndevour.ViewModels.DbConnectionViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ UserDataGrid��5      $��0��5         AutoGenerateColumns$ False��5         SelectionMode$ Single=�5      	   CanUserAddRows$	 False��5      
   SelectionUnit$
 FullRow=�5      $��10q�5       * 	 $MaterialDesignThemes.Wpf.ThemeAssist   Theme$
 Dark=�5#      . 	 (MaterialDesignThemes.Wpf.ElevationAssist   	Elevation$	 Dp4=�5$         MaterialDesignDataGrid#��[  5%      ��5!      �� *Connections+ �� SelectedItem 5"      �� *SelectedConnection+ �� Mode$ TwoWay=�   Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��6%      
IsReadOnly$
 True��6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Name+6N     5)      $ Descripcion��6%   $
 True��6Z    6:   �� *Description+6Z     5*      $ En uso��6%   $
 True��6S    65   �� *	IsDefault+6S   5,      � 5/   
   $��1��6   $��10,10,10,10q�6   .+�51      ( 	 "MaterialDesignThemes.Wpf.ColorZone     CornerRadius$ 5��6'   ���#323232.��52      ��  �� Orientation$ Vertical=�6   $��10q�64   .+�55      �� $��Default��6     MaterialDesignPaperButton#��[ 56      ���#2196F3���#2196F3$��0,5,0,5q�57   H   ��55   /   �� *SetDefaultCommand+57   H   �� 59      $��Agregar��6   #��[ 5:      
����p��
����p��$��0,5,0,5q�5;   R   ��59   /   �� *
AddCommand+5;   R   �� 5?      $��Eliminar��6      MaterialDesignOutlinedButton#��[ 5@      
���  ��
���  ��$��0,5,0,5q�5A   @   ��5?   0   �� *DeleteCommand+5A   @   �� 5C      $��	5,15,5,15q�6    G� 5F      -   5         G�Name$ PasswordBox��5F   "   $��0,5,0,5q�67   $��5q�5G   "   )	 	 #MaterialDesignThemes.Wpf.HintAssist 	  Hint$ CreateDB Pass��6.    % !MaterialDesignOutlinedPasswordBox#��[ 5H   "   �� 5J      $��Unlock��6   #��[ 5K      
����i��
����i��$��0,5,0,5q�5L   H   �� 5N      $��	Create DB��6   $
{�True��61   #��[ 5O      
��� ���
��� ���$��0,5,0,5q�5P   N   ��5N   B   �� *CreateDatabaseCommand+5P   N   �� 5R      -   5        $��Cerrar��5R      #��[ 5S      
����� �
����� �$��0,5,0,5q�5T   B   5V      5W      5Y      5]      5^      