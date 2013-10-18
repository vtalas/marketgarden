var __extends = this.__extends || function (d, b) {
	for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
	function __() { this.constructor = d; }
	__.prototype = b.prototype;
	d.prototype = new __();
};

var MarketData = function (){
	function MarketData(base, alt) {
		this.baseCurrency = base;
		this.altCurrency = alt;
		this.tradeFee = 0;
		this.withdrawalFeeValue = 0;
		this.bid = 0;
		this.ask = 0;
	}
	MarketData.prototype.xx = function () {
		console.log("xxxx")
	};
	MarketData.prototype.xx = function () {
		console.log("xxxx")
	};
	return MarketData;
}();

var Btce = (function (_super) {
	__extends(Btce, _super);
	function Btce(base, alt) {
		_super.apply(this, arguments);
		this.tradeFee = 0.002;
		this.withdrawalFeeValue = 0.001;
		this.bid = 0.001;
		this.ask = 0.001;
	}


	return Btce;
})(MarketData);


var latestCtrl = function ($scope) {
	$scope.baseCurrency = "BTC";
	$scope.altCurrency = "EUR";
	$scope.rate = 0.01583;
	//$scope.baseAmount = 1;
	$scope.altAmount = 1;
	$scope.tradeFee = 0.002;

	var x = new Btce("LTC", "BTC");
	console.log(x)

	$scope.setSymbol = function (base, alt) {
		$scope.altCurrency = alt;
		$scope.baseCurrency = base;
	};

	$scope.$watch("baseAmount", function (value, oldValue) {
		var rate = $scope.rate || 0;
		$scope.altAmountResult = value * rate;
		$scope.baseAmountResult = value;
	});

	$scope.$watch("altAmount", function (value, oldValue) {
		var rate = $scope.rate || 0;
		$scope.baseAmountResult = value / rate;
		$scope.altAmountResult = value;
	});


	console.log("kjabsdkjsa");

};