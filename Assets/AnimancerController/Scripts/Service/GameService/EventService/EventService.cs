using System;
public enum EventID//���������¼�ID
{
    OnDoneStateUIInit
}
/**************************************************************************
����: HuHu
����: 3112891874@qq.com
����: �¼�ϵͳ
**************************************************************************/

public class EventService : MonoSingleton<EventService>
{
    private EventHandler<EventID> EventHandler = new EventHandler<EventID>();

    protected override void Awake()
    {
        base.Awake();
        EventHandler.OnEventInit();
    }

    private void Update()
    {
       EventHandler?.OnEventUpdate();
    }
    private void OnDestroy()
    {
        EventHandler = null;
    }
    /// <summary>
    /// �����¼�����������2���ģ���װ���ഫ�ݲ���
    /// </summary>
    /// <param name="eventID"></param>
    /// <param name="action"></param>
    public void AddEventListening(EventID eventID, Action<object, object> action)
    {
        EventHandler.AddEventListening(eventID, action);
    }
    /// <summary>
    /// ͨ��IDע��ĳһ���¼�����Ὣ���еط�ע��ĸ����¼�����ע��
    /// </summary>
    /// <param name="eventID"></param>
    public void RemoveEventListeningByID(EventID eventID)
    {
        EventHandler.RemoveEventListeningByID(eventID);
    }
    /// <summary>
    /// ����ö�������ע����¼�
    /// </summary>
    /// <param name="target"></param>
    public void RemoveEventListeningByTarget(object target)
    {
        EventHandler.RemoveEventListeningByTarget(target);
    }
    /// <summary>
    /// ���������¼�
    /// </summary>
    /// <param name="eventID"></param>
    /// <param name="param1"></param>
    /// <param name="param2"></param>
    public void SendMessage(EventID eventID, object param1, object param2)
    {
        EventHandler.SentMessage(eventID, param1, param2);
    }
    /// <summary>
    /// ��֡�����¼�
    /// </summary>
    /// <param name="eventID"></param>
    /// <param name="param1"></param>
    /// <param name="param2"></param>
    public void SendMessageByQue(EventID eventID, object param1, object param2)
    {
        EventHandler.SentMessageByQue(eventID, param1, param2);
    }
}
