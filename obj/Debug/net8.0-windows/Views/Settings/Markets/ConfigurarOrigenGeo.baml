   M S B A M L   `   `   `  ����E  ASHEndevour, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:SHEndevour.Views.Settings.Markets!SHEndevour.Views.Settings.Markets  5      _4clr-namespace:SHEndevour.ViewModels.Settings.Markets&SHEndevour.ViewModels.Settings.Markets  5	      ;    5SHEndevour.Views.Settings.Markets.ConfigurarOrigenGeo   5      a ]DevExpress.Xpf.Core.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a ]DevExpress.Xpf.Grid.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af	 bDevExpress.Xpf.Grid.v24.1.Core, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al
 hDevExpress.Xpf.Grid.v24.1.Extensions, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 
 6X   e aDevExpress.Xpf.Printing.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aCdxpr6http://schemas.devexpress.com/winfx/2008/xaml/printing   5      c _MaterialDesignThemes.MahApps, Version=3.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      =local/clr-namespace:SHEndevour.Views.Settings.Markets   5      ?vm4clr-namespace:SHEndevour.ViewModels.Settings.Markets   5	      ���#f1f1f1*  $MaterialDesignThemes.Wpf.ThemeAssist    Theme$  Light=�5
   4    � DataContext 5      I   CSHEndevour.ViewModels.Settings.Markets.GeoOriginManagementViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#   .+�5"      (  "MaterialDesignThemes.Wpf.ColorZone  $��10q�6'   .  (MaterialDesignThemes.Wpf.ElevationAssist   	Elevation$	 Dp4=�5#      $}�False��5$         CornerRadius$ 5��5%      
�������   Mode$ Custom=�5'      $
��Left=�5(      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   
Background �#022534.��5+      �� $��0��6    �� Orientation$ 
Horizontal=�6-   .+�5-      �� $��7q�5.      $��0,0,5,0q�6)   
����iA�   MaterialDesignFlatButton#��[  5/      ��5-      �� *AddGeoCommand+.��50      �� $ 
Horizontal=�6%   .+�51      '  !MaterialDesignThemes.Wpf.PackIcon  $��2q�66   	   Kind$		 Add=�6A   �� 52      $��Agregar Origen��6(   53      54      �� 56      $��7q�57      $��0,0,5,0q�6)   
����� �#��[  58      ��56      �� *ViewGeoCommand+.��59      �� $ 
Horizontal=�6%   .+�5:        $��2q�66   $
	 Edit=�6A   �� 5;      $��Examinar Origen��6(   5<      5=      �� 5?      $��7q�5@      $��0,0,5,0q�6)   
���  ��#��[  5A      ��5?      �� *DeleteGeoCommand+.��5B      �� $ 
Horizontal=�6%   .+�5C        $��2q�66   $	 Remove=�6A   �� 5D      $��Eliminar Origen��6(   5E      5F      5H      5I      5M      %  DevExpress.Xpf.Grid.GridControl  5Q   
   -   5        
  Name$
 MaintenanceRoomsGrid��5Q      $��1��68   $��10q�5S      ) 	 #DevExpress.Xpf.Grid.DataControlBase   SelectionMode$	 Row=�5T         ItemsSource 5R      �� *Geos+   SelectedItem 5U      �� *SelectedGeo+   View 5V      #	  DevExpress.Xpf.Grid.TableView	  5W       	  	AutoWidth$
 True��6    &
 	  DevExpress.Xpf.Grid.DataViewBase 
  AllowSorting$
 True��61      Columns. 5Z      $  DevExpress.Xpf.Grid.GridColumn  $ 	 DevExpress.Xpf.Grid.ColumnBase   	FieldName$ GeoKey��6   $ 	 DevExpress.Xpf.Grid.BaseColumn   Header)  #DevExpress.Xpf.Core.ObjectConverter$ Codigo 60      ReadOnly$
 True��6@     5[      $ Description��6   $ Descripcion del Origen 65   $
 True��6U   5\      5^      5_      