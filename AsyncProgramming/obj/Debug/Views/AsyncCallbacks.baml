   M S B A M L   `   `   `  ����K  GAsyncProgramming, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:AsyncProgramming.ViewsAsyncProgramming.Views  5      +    %AsyncProgramming.Views.AsyncCallbacks   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:AsyncProgramming.Views     5        N� Title$  AsyncCallbacks��5	      .��5      �  � RowDefinitions 5   
   �� 5      $	��200 �6   �� 5      $	��180 �6   �� 5      $	��180 �6   �� 5      $	��180 �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      ��  � 	Resources 5         ButtonStyle �� 
TargetType �� Property �� Value��%Q   &	        �� 5      " ��60   .�5      ��  � ��$ 5q�63   5      5      .+�5      �� -   5         ��Name$ 
btnTaskRun��5      $��Task.Run��6-   $	��153��6@   #��[  6e   �� 5      -   5        $ btnAsyncCall��5      $��
Async call��6/   $	��153��6D   #��[  6k   �� 5      -   5        $ btnAsyncCall_UIBlock��5      $��Async call with UI Block��67   $	��153��6Z   #��[  6�   �� 5      -   5        $ btnAsyncCall_ReturnValue��5      $"��Async call with return value��6;   $	��153��6b   #��[  6�   �� 5      -   5        $! btnAsyncCall_InvokeCallback��5      $ ��Async call invoke callback��6>   $	��153��6c   #��[  6�   5      �� 5      .+�5       �� -   5         ��Name$ 	txtOutput��5       $
��Left=�6/   $��10q�6J   $
��Wrap=�6V   $��Hello��6j   $	��Top=�6w   $	��181��6�   $	��212��6�   
���  ��
�������6�   5!      5"      �� 5#   
   $��1��6   .+�5$      �� $ ��APM Pattern (Factory.Task)��6   $��24(�69   �� 5%      $��	Enter Url��6   �� 5&      -   5        	 ��Name$	 txtUrl��5&      $��23��6&   
 �� TextWrapping$

 Wrap=�62   $��https://github.com��6F   �� 5'      -   5        $ btnCheckUrl��5'      $��Check��6*   $	��153��6:   $��5q�6F   6Q   �� 5(      -	   5         ��Name$ 	lblResult��5(      $��Awaiting result��6'   $��Center=�6A   5)      �� 5*   
   $��2��6   .+�5+      �� $��ERROR HANDLING��6   $��24(�6-   �� 5,      $��	Enter Url��6   �� 5-      -
   5        $	 txtUrl2��5-      $��23��6'   $

 Wrap=�63   $��http://fourthcoffee/bogus��6G   �� 5.      -   5        $ btnErrorHandler2��5.      $��Check��6/   $	��153��6?   $��5q�6K   6V   �� 5/      -   5        $ 
lblResult2��5/      $��Awaiting result��6(   $��Center=�6B   50      �� 51   
   $��3��6   .+�52      �� $��UnobservedTaskException��6   $��24(�66   �� 53      $��	Enter Url��6   �� 54      -   5        $	 txtUrl3��54      $��23��6'   $

 Wrap=�63   $��http://fourthcoffee/bogus��6G   �� 55      -   5        $  btnUnobservedTaskException��55      $��Check��69   $	��153��6I   $��5q�6U   6`   �� 56      -   5        $ 
lblResult3��56      $��Awaiting result��6(   $��Center=�6B   57      58      59      