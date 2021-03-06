﻿using CommerceTraining.Models.Catalog;
using CommerceTraining.Models.ViewModels;
using EPiServer;
using EPiServer.Commerce.Catalog;
using Mediachase.Commerce.Catalog;
using Mediachase.Commerce.InventoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommerceTraining.Controllers
{
    public class InventoryDemoController : Controller
    {
        private ReferenceConverter _referenceConverter;
        private IContentLoader _contentLoader;
        private AssetUrlResolver _assetUrlResolver;
        private IInventoryService _inventoryService;

        public InventoryDemoController(ReferenceConverter referenceConverter, IContentLoader contentLoader,
            AssetUrlResolver assetUrlResolver, IInventoryService inventoryService)
        {
            _referenceConverter = referenceConverter;
            _contentLoader = contentLoader;
            _assetUrlResolver = assetUrlResolver;
            _inventoryService = inventoryService;
        }
        // GET: InventoryDemo
        public ActionResult Index()
        {
            var viewModel = new InventoryDemoViewModel();
            ModelFiller(viewModel);

            return View(viewModel);
        }

        public void ModelFiller(InventoryDemoViewModel viewModel)
        {
            var shirtRef = _referenceConverter.GetContentLink("Long Sleeve Shirt White Small_1");
            viewModel.Shirt = _contentLoader.Get<ShirtVariation>(shirtRef);
            viewModel.ImageUrl = _assetUrlResolver.GetAssetUrl(viewModel.Shirt);

        }

        public ActionResult EditInventory(string code, string warehouseCode)
        {
            var viewModel = new InventoryDemoViewModel();
            ModelFiller(viewModel);

            return View("Index", viewModel);
        }

        public ActionResult UpdateInventory([Bind(Prefix = "SelectedInvRecord")]InventoryRecord inventoryRecord)
        {
            var viewModel = new InventoryDemoViewModel();
            ModelFiller(viewModel);

            return View("Index", viewModel);
        }

        public ActionResult SimulatePurchase(InventoryDemoViewModel viewModel)
        {
            ModelFiller(viewModel);

            return View("Index", viewModel);
        }

        public ActionResult CompletePurchase(InventoryDemoViewModel viewModel)
        {
            ModelFiller(viewModel);

            return View("Index", viewModel);
        }

        public ActionResult CancelPurchase(InventoryDemoViewModel viewModel)
        {
            ModelFiller(viewModel);

            return View("Index", viewModel);
        }
    }
}