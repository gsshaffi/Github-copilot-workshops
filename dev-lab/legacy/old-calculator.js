// Legacy stamp duty calculator — JavaScript
// Exercise: Use Copilot to convert this to C# or TypeScript
// Note: The rates below are simplified and may not reflect current HMRC rates

function calculateStampDuty(purchasePrice, isFirstTimeBuyer, isAdditionalProperty) {
    var tax = 0;
    var remaining = purchasePrice;

    if (isFirstTimeBuyer && purchasePrice <= 625000) {
        // First-time buyer relief
        var bands = [
            { threshold: 425000, rate: 0 },
            { threshold: 625000, rate: 0.05 }
        ];
        
        var prev = 0;
        for (var i = 0; i < bands.length; i++) {
            var band = bands[i];
            var bandAmount = Math.min(remaining, band.threshold - prev);
            if (bandAmount > 0) {
                tax += bandAmount * band.rate;
                remaining -= bandAmount;
            }
            prev = band.threshold;
        }
    } else {
        // Standard rates
        var bands = [
            { threshold: 250000, rate: 0 },
            { threshold: 925000, rate: 0.05 },
            { threshold: 1500000, rate: 0.10 },
            { threshold: Infinity, rate: 0.12 }
        ];
        
        var prev = 0;
        for (var i = 0; i < bands.length; i++) {
            var band = bands[i];
            var bandAmount = Math.min(remaining, band.threshold - prev);
            if (bandAmount > 0) {
                tax += bandAmount * band.rate;
                remaining -= bandAmount;
            }
            prev = band.threshold;
            if (remaining <= 0) break;
        }
    }

    // Additional property surcharge
    if (isAdditionalProperty) {
        tax += purchasePrice * 0.03;
    }

    return {
        purchasePrice: purchasePrice,
        stampDuty: tax,
        effectiveRate: ((tax / purchasePrice) * 100).toFixed(2) + '%',
        totalCost: purchasePrice + tax
    };
}

// Usage examples
console.log(calculateStampDuty(300000, true, false));   // First-time buyer
console.log(calculateStampDuty(500000, false, false));   // Standard
console.log(calculateStampDuty(750000, false, true));    // Additional property
