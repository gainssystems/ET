﻿namespace ET.Client
{
	[MessageHandler(SceneType.Demo)]
	public class M2C_CreateUnitsHandler : MessageHandler<M2C_CreateUnits>
	{
		protected override async ETTask Run(Session session, M2C_CreateUnits message)
		{
			Scene currentScene = session.Root().CurrentScene();
			UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
			
			foreach (UnitInfo unitInfo in message.Units)
			{
				if (unitComponent.Get(unitInfo.UnitId) != null)
				{
					continue;
				}
				Unit unit = UnitFactory.Create(currentScene, unitInfo);
			}
			await ETTask.CompletedTask;
		}
	}
}