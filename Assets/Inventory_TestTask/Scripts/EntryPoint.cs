using System.Collections.Generic;
using UnityEngine;


namespace Assets.Inventory_TestTask
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private ScreenView _screenView;
        private InputSystem_Actions _gameInput;

        private const string OWNER_1 = "Player 1";
        private const string OWNER_2 = "Player 2";

        private readonly string[] _itemIds = { "Gun", "Shotgun", "Machete", "Ammo" };

        private InventoryService _inventoryService;
        private ScreenController _screenController;

        private string _cachedOwnerId;

        private void Start()
        {
            _inventoryService = new InventoryService();

            var inventoryDataPlayer1 = CreateTestInventory(OWNER_1);
            _inventoryService.RegisterInventory(inventoryDataPlayer1);

            var inventoryDataPlayer2 = CreateTestInventory(OWNER_2);
            _inventoryService.RegisterInventory(inventoryDataPlayer2);

            _screenController = new ScreenController(_inventoryService, _screenView);
            _screenController.OpenInventory(OWNER_1);
            _cachedOwnerId = OWNER_1;

            _gameInput = new InputSystem_Actions();
            _gameInput.Enable();
        }

        private void Update()
        {
            if (_gameInput.Player.OpenFirstInventory.triggered)
            {
                _screenController.OpenInventory(OWNER_1);
                _cachedOwnerId = OWNER_1;
            }

            if (_gameInput.Player.OpenSecondInventory.triggered)
            {
                _screenController.OpenInventory(OWNER_2);
                _cachedOwnerId = OWNER_2;
            }

            if (_gameInput.Player.AddItem.triggered)
            {
                var randomIdex = Random.Range(0, _itemIds.Length);
                var randomItemId = _itemIds[randomIdex];
                var randomAmount = Random.Range(1, 50);
                var result = _inventoryService.AddItemsToInventory(_cachedOwnerId, randomItemId, randomAmount);

                Debug.Log($"Item added: {randomItemId}." +
                    $"Amount added: {result.ItemsAddedAmount}.");
            }

            if (_gameInput.Player.RemoveItem.triggered)
            {
                var randomIdex = Random.Range(0, _itemIds.Length);
                var randomItemId = _itemIds[randomIdex];
                var randomAmount = Random.Range(1, 50);
                var result = _inventoryService.RemoveItems(_cachedOwnerId, randomItemId, randomAmount);

                Debug.Log($"Item remove: {randomItemId}." +
                    $"Trying to remove: {result.ItemsToRemoveAmount}." +
                    $"Success: {result.Success}");
            }
        }

        private InventoryGridData CreateTestInventory(string ownerId)
        {
            var size = new Vector2Int(3, 4);
            var createdInventorySlots = new List<InventorySlotData>();
            var length = size.x * size.y;

            for (int i = 0; i < length; i++)
            {
                createdInventorySlots.Add(new InventorySlotData());
            }

            var createdInventoryData = new InventoryGridData
            {
                OwnerId = ownerId,
                Size = size,
                Slots = createdInventorySlots
            };

            return createdInventoryData;
        }
    }
}
