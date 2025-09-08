// traverese a Map using for...of loop

const scores1 = new Map ([

['Alice', 95], ['Bob', 87], ['Eve', 78], ]);

for (const [name, score] of scores1) {

    console.log(`${name}: ${score}`);

}

// traverse a Set using for... of loop

const uniqueNumbers = new Set([1, 2, 3, 4, 5]);

for (const number of uniqueNumbers) {

console.log(number);
}