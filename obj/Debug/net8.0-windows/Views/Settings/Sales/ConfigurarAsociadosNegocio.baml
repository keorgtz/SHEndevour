   M S B A M L   `   `   `  ����E  ASHEndevour, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:SHEndevour.ViewModels.Settings.Sales$SHEndevour.ViewModels.Settings.Sales  5	      Q-clr-namespace:SHEndevour.Views.Settings.SalesSHEndevour.Views.Settings.Sales  5
      @    :SHEndevour.Views.Settings.Sales.ConfigurarAsociadosNegocio   5      a ]DevExpress.Xpf.Core.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      a ]DevExpress.Xpf.Grid.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af	 bDevExpress.Xpf.Grid.v24.1.Core, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49al
 hDevExpress.Xpf.Grid.v24.1.Extensions, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid  	 
 5      e aDevExpress.Xpf.Printing.v24.1, Version=24.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aCdxpr6http://schemas.devexpress.com/winfx/2008/xaml/printing   5      c _MaterialDesignThemes.MahApps, Version=3.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      =vm2clr-namespace:SHEndevour.ViewModels.Settings.Sales   5	      ;local-clr-namespace:SHEndevour.Views.Settings.Sales   5
      ���#f1f1f1*  $MaterialDesignThemes.Wpf.ThemeAssist    Theme$  Light=�5   4    � DataContext 5      D  >SHEndevour.ViewModels.Settings.Sales.BusisnessPartnerViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#   .+�5#      (  "MaterialDesignThemes.Wpf.ColorZone  $��10q�6'   .  (MaterialDesignThemes.Wpf.ElevationAssist   	Elevation$	 Dp4=�5$      $}�False��5%         CornerRadius$ 5��5&      
�������   Mode$ Custom=�5(      $
��Left=�5)      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   
Background �#022534.��5,      �� $��0��6    �� Orientation$ 
Horizontal=�6-   .+�5.      �� $��5q�5/      $��0,0,5,0q�6%   
����iA�   MaterialDesignFlatButton#��[  50   	   ��5.      �� *AddSegmentCommand+.��51      �� $ 
Horizontal=�6%   .+�52      '  !MaterialDesignThemes.Wpf.PackIcon  $��2q�66   	   Kind$		 Add=�6A   �� 53      $��Agregar Asociado��6(   54      55      �� 57      $��5q�58      $��0,0,5,0q�6%   
����� �#��[  59   	   ��57      �� *ViewSegmentCommand+.��5:      �� $ 
Horizontal=�6%   .+�5;        $��2q�66   $
	 Edit=�6A   �� 5<      $��Examinar Asociado��6(   5=      5>      �� 5@      $��5q�5A      $��0,0,5,0q�6%   
���  ��#��[  5B   	   ��5@      �� *DeleteSegmentCommand+.��5C      �� $ 
Horizontal=�6%   .+�5D        $��2q�66   $	 Remove=�6A   �� 5E      $��Eliminar Asociado��6(   5F      5G      5I      5J      5N      %  DevExpress.Xpf.Grid.GridControl  5R   
   -   5        
  Name$
 BusisnessPartnerGrid��5R      $��1��68   $��10q�5T      ) 	 #DevExpress.Xpf.Grid.DataControlBase   SelectionMode$	 Row=�5U         ItemsSource 5S      �� *
Segments+   SelectedItem 5V      �� *SelectedSegment+   View 5W      #	  DevExpress.Xpf.Grid.TableView	  5X       	  	AutoWidth$
 True��6    &
 	  DevExpress.Xpf.Grid.DataViewBase 
  AllowSorting$
 True��61      Columns. 5[      $  DevExpress.Xpf.Grid.GridColumn  $ 	 DevExpress.Xpf.Grid.ColumnBase   	FieldName$ 
PartnerKey��6   $ 	 DevExpress.Xpf.Grid.BaseColumn   Header)  #DevExpress.Xpf.Core.ObjectConverter$ Cuenta 64      ReadOnly$
 True��6D     5\      $ RazonSocial��6   $ Razon Social 65   $
 True��6K     5]      $ NombreComercial��6   $ Nombre Comercial 69   $
 True��6S     5^      $ 	Direccion��6   $ 	Direccion 63   $
 True��6F     5_      $ CodigoPostal��6   $ Codigo Postal 66   $
 True��6M     5`      $ RegimenFiscal��6   $ Regimen Fiscal 67   $
 True��6O     5a      $	 RFC��6   $	 RFC 6-   $
 True��6:     5b      $ 	GeoOrigin��6   $ Origen 63   $
 True��6C     5c      $ Observaciones��6   $ Observaciones 67   $
 True��6N     5d      $ Email��6   $ Email 6/   $
 True��6>     5e      $ Telefono��6   $ Telefono 62   $
 True��6D   5f      5h      5i      