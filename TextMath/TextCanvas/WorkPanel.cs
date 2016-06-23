using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TextCanvas
{
   public class WorkPanel:Canvas
    {
       private List<Visual> visuals = new List<Visual>();
       private List<DrawingVisual> hits = new List<DrawingVisual>();

       protected override System.Windows.Media.Visual GetVisualChild(int index)
       {
           return visuals[index];
       }

       protected override int VisualChildrenCount
       {
           get
           {
               return visuals.Count; 
           }
       }

       public void AddVisual(Visual visual)
       {
           visuals.Add(visual);

           base.AddVisualChild(visual);
           base.AddLogicalChild(visual);
       }

       public void ClearVisuals()
       {
           foreach (var item in visuals)
           {
               base.RemoveVisualChild(item);
               base.RemoveLogicalChild(item);
           }
           visuals.Clear();
       }

       public void DeleteVisual(Visual visual)
       {
           visuals.Remove(visual);

           base.RemoveVisualChild(visual);
           base.RemoveLogicalChild(visual);

       }

       public DrawingVisual GetVisual(Point point)
       {
           HitTestResult hitResult = VisualTreeHelper.HitTest(this, point);
           return hitResult.VisualHit as DrawingVisual;
       }

       public List<DrawingVisual> GetSelectedVisuals(Geometry region)
       {
           hits.Clear();
           GeometryHitTestParameters parameters = new GeometryHitTestParameters(region);
           HitTestResultCallback callback = new HitTestResultCallback(HitTestCallback);
           VisualTreeHelper.HitTest(this, null, callback, parameters);
           return hits;
       }

       private HitTestResultBehavior HitTestCallback(HitTestResult result)
       {
           GeometryHitTestResult geometryResult = (GeometryHitTestResult)result;
           DrawingVisual vsiual = result.VisualHit as DrawingVisual;
           if (visuals!=null&&
               geometryResult.IntersectionDetail==IntersectionDetail.Intersects)
           {
               hits.Add(vsiual);    
           }
           return HitTestResultBehavior.Continue;
       }

    }
}
