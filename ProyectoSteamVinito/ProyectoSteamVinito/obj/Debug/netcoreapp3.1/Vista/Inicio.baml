   M S B A M L   `   `   `  ����N  JProyectoSteamVinito, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ProyectoSteamVinito.VistaProyectoSteamVinito.Vista  5   	   &     ProyectoSteamVinito.Vista.Inicio   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:ProyectoSteamVinito.Vista     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  Proyecto Vinito -- Inicio��5	   	   $	��450��6+   $	��800��68   $	��850��5
   	   $	��500��6   $	��750��6(   $
��1000��68   .��5      � .+�5   
   7  1MaterialDesignThemes.Wpf.Transitions.Transitioner  -   5          Name$ transitioner��5   &    �� SelectedIndex$ 0��6<   !   AutoApplyTransitionOrigins$
 True��6N   .@�5      -   'ProyectoSteamVinito.Vista.PantallaCarga  6%   <  6MaterialDesignThemes.Wpf.Transitions.TransitionerSlide  5      5        5         ForwardWipe 5      4  .MaterialDesignThemes.Wpf.Transitions.SlideWipe  5         	Direction$ Right=�6/   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffects 5!      ;  5MaterialDesignThemes.Wpf.Transitions.TransitionEffect  5"         Kind$ SlideInFromRight=�66   6P   .��5'      �  � RowDefinitions 5)      �� 5*      $	��100 �6(   �� 5+      .+�5.      � 	 � ColumnDefinitions	 5/      �� 50      �� 51      .+�53      �� 
 �� Orientation$
 
Horizontal=�6%   .+�54      �� -   5        $��0q�54   %   $
��10,0q�61   $��60��6?   $��60��6K    � ToolTip$ Inicio��6�   ��6k   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ ContentCopy=�   Size 50{�55   %   �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window56      �� 57      -   5        $��0q�57   %   $
��10,0q�61   $��60��6?   $��60��6K   $ Ajustes��6�    � Cursor$
 Hand��58   �   ��57   m     $ Settings=� 50{�58   %   �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window59      5:      �� 5;      $��1��6!   $��Right=�61   $��/Vista/logo-IESGP-FP.png��6M   $��10q�6o   5<      '   !ProyectoSteamVinito.Vista.Ajustes  5=      -   5          Name$ vistaAjustes��5=   $   $��1��6:   5>      5?        5C         BackwardWipe 5F        5G       5J        5K      $ Right=�6/   .��5P      �  5Q      �� 5R      $	��100 �6(   �� 5S      .+�5U      � 	 5V      �� 5W      �� 5X      .+�5Z      �� $
 
Horizontal=�6%   .+�5[      �� -   5        $��0q�5[   %   $
��10,0q�61   $��60��6?   $��60��6K   $ Inicio��6�   $
 Hand��5\   �   ��5[   k     $ ContentCopy=� 50{�5\   %   �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window5]      �� 5^      -   5        $��0q�5^   %   $
��10,0q�61   $��60��6?   $��60��6K   $ Ajustes��6�   $
 Hand��5_   �   ��5^   m     $ Settings=� 50{�5_   %   �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window5`      5a      �� 5b      $��1��6!   $��Right=�61   $��/Vista/logo-IESGP-FP.png��6M   $��10q�6o   5c      .	   (ProyectoSteamVinito.Vista.vistaPrincipal	  5d      -   5         	 Name$ vistaPrincipal��5d   ,   $��1��6D   5e      5f      5h      �� 5l   
   -	   5         ��Name$ btnSiguiente��5l      $��1��6'      MaterialDesignFlatButton#���   64   $��5q�6g      MoveNextCommand#��Z 5m      $��Right=�5n      $��Bottom=�61   $
 Hand��6L   $y�	Collapsed=�6Z   6s   �� 5o   
   -
   5        $ btnAnterior��5o      $��1��6&   #���   63   $��5q�6f      MovePreviousCommand#��Z 5p      $��Right=�5q      $��Bottom=�61   $
 Hand��6L   $y�	Collapsed=�6Z   6s   5s      5t      