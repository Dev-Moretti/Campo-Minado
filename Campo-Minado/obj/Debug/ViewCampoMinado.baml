   M S B A M L   `   `   `  ����G  CCampo-Minado, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Campo_MinadoCampo_Minado  5   	   "    Campo_Minado.ViewCampoMinado   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Campo_Minado     5   	   -   5          �Name$  CampoMinado��5	   	    � Title$ Campo Minado��5   	    � WindowState$ 	Maximized=�5
   	   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � -   5        $��GCampoMinado��5      $��1��5      $��1��5      $��0,0,0,0q�5      5      �� 5!   
   -   5        $��GVisorTimer��5$      $��0��5!      $��1��5"      $��35(�5#      $��	0,-10,0,0q�5%      $��Bottom=�5&      $��Center=�5'      ��5(      ��  �� Path$ TempoDecorrido� �� Mode$ OneWay=�5)      m� 5+   
   5-      �� 5/   
   -   5        $��	BTVoltar2��58      $��0��5/      $��1��50      $��30��51      $��70��52      $��VOLTAR��53      $��16(�54      $
��Left=�55      $��Center=�56      $��260,-15,0,0q�57      5:      5;      5=      