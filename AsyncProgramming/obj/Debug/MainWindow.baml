   M S B A M L   `   `   `  ����K  GAsyncProgramming, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:AsyncProgrammingAsyncProgramming  5   	   !    AsyncProgramming.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:AsyncProgramming     5   	     � Title$  
MainWindow��5   	   $	��700��5	   	   $
��1000��5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowState$ 	Maximized=�5   	    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��$	 120��6&   �� 5       � ��
 ��+��6+   �� 5       � ��
 �����6+   �� 5       � ��$ Right=�64   �� 5       � ��$ 5q�6'   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Right=�6.   .+�5      �� -   5        	 ��Name$	 btnBasicTasks��5   G   $��Basic Tasks��6   6G   �� 5      -   5        $	 btnCancelToken��5   O   $��Cancellation Token��6   6O   �� 5      -   5        $	 btnCallback��5   Z   $&�� Async Callbacks + Error Handling��6   $	��200��6o   �� 5       -   5        $	 	btnFileIO��5    @   $��File I/O��6   6@   5!       � 5#   
   -   5        $��WinFrame��5#      
  � NavigationUIVisibility$
 Hidden=�6      � Source$ /Views/BasicTasks.xaml?�6@   $��1��6`   $��20q�6m   6|   5%      5&      