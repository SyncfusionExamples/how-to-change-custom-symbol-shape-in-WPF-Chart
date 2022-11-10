# How to show different data marker based on the value in the WPF Chart (SfChart)?

This example explains how to show a custom data marker based on value in the WPF Chart series.
 
You can show the custom data marker in chart using the [ChartAdornmentInfo](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.AdornmentSeries.html#Syncfusion_UI_Xaml_Charts_AdornmentSeries_AdornmentsInfo) [SymbolTemplate](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartAdornmentInfoBase.html#Syncfusion_UI_Xaml_Charts_ChartAdornmentInfoBase_SymbolTemplate) property by the following steps.

You can display a custom symbol by following this [KB](https://www.syncfusion.com/kb/11000) article.

**How to show different data marker based on value in the WPF chart?**

In addition, you can show multiple symbols based on the value by using the **DataTemplateSelector** to select the symbols and assign the declared data template to the [SymbolTemplate](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartAdornmentInfoBase.html#Syncfusion_UI_Xaml_Charts_ChartAdornmentInfoBase_SymbolTemplate) property as per the following code example.

```
<syncfusion:SfChart >
          <syncfusion:SfChart.Resources>
              <ResourceDictionary>
                  <DataTemplate x:Key="CrossTemplate">
                      ……..
                  </DataTemplate>
 
                  <DataTemplate x:Key="DiamondTemplate">
                      <Grid Height="15" Width="15">
                         <Path  Stretch="Fill" Stroke="{Binding Interior}" Fill="{Binding Interior}"  Data="F1 M 156.37,93.7292L 134.634,
71.8159L 112.906,49.9025L 91.1711,71.8159L 69.4364,93.7292L 70.1524,93.7292L 91.8844,115.644L 113.623,137.556L 135.362,
115.644L 157.09,93.7292L 156.37,93.7292 Z "  />
                      </Grid>
                  </DataTemplate>
                
                  <local:SymbolDataTemplateSelector HighValueTemplate="{StaticResource CrossTemplate}" 
LowValueTemplate="{StaticResource DiamondTemplate}" x:Key="SymbolTemplateSelectorKey"/>
 
                  <DataTemplate x:Key="symbolTemplate">
                      <ContentControl Content="{Binding}" ContentTemplateSelector="{StaticResource  SymbolTemplateSelectorKey}" />
                  </DataTemplate>
          </ResourceDictionary>
          </syncfusion:SfChart.Resources>
          ………        
          <syncfusion:LineSeries ItemsSource="{Binding Data}" XBindingPath="XValue" YBindingPath="YValue">
                <syncfusion:LineSeries.AdornmentsInfo>
                    <syncfusion:ChartAdornmentInfo SymbolTemplate="{StaticResource symbolTemplate}">
                    </syncfusion:ChartAdornmentInfo>
                </syncfusion:LineSeries.AdornmentsInfo>
          </syncfusion:LineSeries>               
</syncfusion:SfChart>
```

```
public class SymbolDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate HighValueTemplate { get; set; }
    public DataTemplate LowValueTemplate { get; set; }
 
    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        if (item == null) return null;
 
        var adornment = item as ChartAdornment;            
        var model = adornment.Item as Model;
        //You can change the value based on your requirement
        if (model.YValue > 150)
        {
            return HighValueTemplate;
        }
        else
        {
            return LowValueTemplate;
        }
    }
}
```

## Output:

![Custom SymbolTemplate based on value in WPF Chart](https://user-images.githubusercontent.com/53489303/200643888-d91a87fb-6d81-4f01-90a9-1f1f421c6e1e.png)

KB article - [How to show different data marker based on the value in the WPF Chart?](https://www.syncfusion.com/kb/11001/how-to-show-different-data-marker-based-on-the-value-in-the-wpf-chart)
