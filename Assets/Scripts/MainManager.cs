using Ulma.Util;

public class MainManager : SingletonMonoBehaviour<MainManager>{
    private void Start(){
        var wallStayUIModel = FindObjectOfType<WallStayTimeUIModel>();
        var wallStayUIView = FindObjectOfType<WallStayTimeUIView>();

        wallStayUIModel.OnUpdate += wallStayUIView.SetAmount;
    }
}
