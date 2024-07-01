/**************************************************************************\
    Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeConsole.Engine
{
    public class SceneData
    {
        public int Id => m_id;
        public string Name => m_name;
        public List<IGameObject> GameObjects => m_gameObjects;
        private int m_id;
        private string m_name;
        private List<IGameObject> m_gameObjects;
        
        public SceneData(int id, string name, List<IGameObject> gameObjects)
        {
            m_id = id;
            m_name = name;
            m_gameObjects = gameObjects;
        }
    }
}
