
var app = angular.module("myApp", []);

//Global Function
app.run(function ($rootScope, $http, $window) {
    $rootScope.BasketSize = 0;
    $rootScope.BasketGlobalFunction = function () {
        $http({
            url: "/Home/Basket",
            method: "Get"
        }).then(function (response) {
            $rootScope.BasketSize = response.data.length;
            $rootScope.Basket = response.data;
        }, function () {
            alert("hata");
        });
    };
});

app.controller("Catalog", function ($scope, $http, $window) {

    $scope.CurrentDate = new Date().toLocaleDateString().toString();

    $scope.BrandData = [];

    $scope.Sortingenum = 0;

    $scope.CatalogFilterData = [];

    $scope.BrandIdFilterList = [];

    $scope.CatalogFilterIdList = [];

    $scope.CatId = 0;

    $scope.pageNum = 0;

    $scope.BrandFilter = function (data) {
        if (data.checked === true) {
            $scope.BrandIdFilterList.push(data.BrandId);
        }
        else {
            var index = $scope.BrandIdFilterList.indexOf(data.BrandId);
            if (index > -1) {
                $scope.BrandIdFilterList.splice(index, 1);
            }
        }
        $scope.GetAllData($scope.CatId, $scope.pageNum);
    }

    $scope.SpeficationFilter = function (data) {

        var model = {
            SpecificationAttributeId: data.SpecificationAttributeId,
            SpeficationAttributeOptionId: data.Id
        }
        if (data.checked === true) {
            $scope.CatalogFilterIdList.push(model);
        }
        else {
            var index = $scope.CatalogFilterIdList.findIndex((x) => x.SpeficationAttributeOptionId == data.Id);
            if (index > -1) {
                $scope.CatalogFilterIdList.splice(index, 1);
            }
        }
        $scope.GetAllData($scope.CatId, $scope.pageNum);
    }

    $scope.GetAllData = function (CatId, pageNum) {
        $scope.CatId = CatId;
        $scope.pageNum = pageNum; 
        $('.loadingbody').css("display", "flex").delay(10).fadeIn("slow");

        $http({
            method: "get",
            url: "../Catalog/GetCatalogProduct",
            params: {
                id: CatId,
                pageNumber: pageNum,
                pageSize: 12,
                SelectedBrand: $scope.BrandIdFilterList.toString(),
                MinPrice: $scope.minprice,
                MaxPrice: $scope.maxprice,
                sortingid: $scope.Sortingenum,
                SelectFilter: JSON.stringify($scope.CatalogFilterIdList)
            }
        }).then(function (response) {
            $scope.ProductData = response.data.Productlist;
            if ($scope.BrandData.length === 0)
                $scope.BrandData = response.data.BrandList;

            $scope.PaggingTemplate(response.data.ProductCount, pageNum);

        }, function () {
            alert("Hata");
        });
        $('.loadingbody').css("display", "none").delay(10).fadeOut('slow');
    };

    $scope.GetAllBrandFilter = function (CatId, pageNum) {
        $http({
            method: "get",
            url: "../Catalog/GetCatalogBrand",
            params: {
                categoryId: CatId,
            }
        }).then(function (response) {

            if ($scope.BrandData.length === 0)
                $scope.BrandData = response.data;

        }, function () {
            alert("Hata");
        });
    }

    $scope.GetAllCategoryFilter = function (CatId) {
        $http({
            url: "../Catalog/GetAllCategoryFilter",
            method: "GET",
            params: {
                CategoryId: CatId
            }
        }).then(function (response) {
            if ($scope.CatalogFilterData.length === 0) {
                $scope.CatalogFilterData = response.data.CategorySpeficationList;
            }
        }, function () {
            alert("Hata");
        });
    };

    $scope.PaggingTemplate = function (totalPage, currentPage) {
        $scope.showForwardBtn = true;
        $scope.TotalPages = totalPage;
        $scope.CurrentPage = currentPage;
        $scope.PageNumberArray = Array();

        var countIncr = 1;

        if (currentPage === 2) {
            currentPage = currentPage - 1;
        } else if (currentPage > 2) {
            currentPage = currentPage - 2;
        }

        for (var i = currentPage; i <= totalPage; i++) {
            $scope.PageNumberArray[0] = currentPage;
            if (totalPage !== currentPage && $scope.PageNumberArray[countIncr - 1] !== totalPage) {
                $scope.PageNumberArray[countIncr] = i + 1;
            }
            countIncr++;
        };
        $scope.PageNumberArray = $scope.PageNumberArray.slice(0, 5);
        $scope.FirstPage = 1;
        $scope.LastPage = totalPage;
        if (totalPage !== currentPage) {
            $scope.ForwardOne = currentPage + 1;
        }
        $scope.BackwardOne = currentPage - 1;
        if (totalPage === currentPage) {
            $scope.showForwardBtn = false;
        }


    };
});

app.controller("ProductDetail", function ($scope, $http, $window) {

    $scope.AnotherProductList = [];

    $scope.AnotherProduct = function () {
        $http({
            url: "../ProductDetail/GetAnotherProduct",
            method: "GET",
        }).then(function (response) {
            if ($scope.AnotherProductList.length === 0) {
                $scope.AnotherProductList = response.data;
            }
        }, function () {
                alert("hata");
        });
    }

});

app.controller("Basket", function ($scope, $http, $rootScope,$window) {

    //$scope.BasketSize = 0;
    //$scope.Basket = function (BasketSize) {
    //    $scope.BasketSize = BasketSize;
    //    $http({
    //        url: "/Home/Basket",
    //        method: "Get"
    //    }).then(function (response) {
    //        $scope.BasketSize = response.data.length;
    //        $scope.Basket = response.data;
    //    }, function () {
    //        alert("hata");
    //    });
    //};
    $scope.Basketadded = function (productId, combinationId, productPiece, productStockPiece) {

        if (productStockPiece > productPiece) {
            $http({
                url: "/Home/BasketAdded",
                method: "Post",
                params: {
                    ProductId: productId,
                    CombinationId: combinationId,
                    ProductPiece: productPiece
                }
            }).then(function (response) {
                swal("Başarılı", "Ürününüz Sepete Eklendi", "success");
                $rootScope.BasketGlobalFunction();

            }, function () {
                swal("Hata", "Ürün Eklerken bir hata" + productStockPiece, "error");
            }
            );
        }
        else {
            swal("Hata", "Ekleyebileceğin maximum adet" + productStockPiece, "error");
        }

    };

});

app.controller("CheckOut", function ($scope, $http, $rootScope, $window) {

    $scope.GetCheckout = function () {
        $http({
            url: "/Home/GetCheckout",
            method: "Get"
        }).then(function (response) {
            $scope.CheckoutData = response.data;
        }, function () {
            alert("hata");
        });
    };
    $scope.DeleteCheckoutProduct = function (productId,combinationId,productPiece) {
        $http({
            url: "/Home/DeleteProductCheckout",
            method: "Post",
            params: {
                ProductId: productId,
                CombinationId: combinationId,
                ProductPiece: productPiece
            }
        }).then(function (response) {        
            swal("Başarılı", "Ürününüz Sepetten Silindi", "success");
            $scope.GetCheckout();
            $rootScope.BasketGlobalFunction();
        }, function () {
            swal("Hata", "Ürün Silerken bir hata", "error");
        });
    };
    $scope.ChangePieceProduct = function (productId,productCombinatonId = 0,productPiece) {
        $('.loadingbody').css("display", "flex").delay(10).fadeIn("slow");
        $http({
            url: "/Home/UpdateProductPiece",
            method: "Post",
            params: {
                ProductId: productId,
                CombinationId: productCombinatonId,
                ProductPiece: productPiece
            }
        }).then(function (response) {
            $scope.GetCheckout();
            $rootScope.BasketGlobalFunction();
        }, function () {
            swal("Hata", "Ürün Adeti Güncelendi" + productStockPiece, "error");
        });
        $('.loadingbody').css("display", "none").delay(10).fadeOut('slow');
    };
});

app.filter("groupBy", ["$parse", "$filter", function ($parse, $filter) {
    return function (array, groupByField) {
        var result = [];
        var prev_item = null;
        var groupKey = false;
        var filteredData = $filter('orderBy')(array, groupByField);

        for (var i = 0; i < filteredData.length; i++) {
            groupKey = false;
            if (prev_item !== null) {
                if (prev_item[groupByField] !== filteredData[i][groupByField]) {
                    groupKey = true;
                }
            } else {
                groupKey = true;
            }
            if (groupKey) {
                filteredData[i]['group_by_key'] = true;
            } else {
                filteredData[i]['group_by_key'] = false;
            }
            result.push(filteredData[i]);
            prev_item = filteredData[i];
        }
        return result;
    };
}]);






