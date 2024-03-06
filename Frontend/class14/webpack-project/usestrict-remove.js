// const fs = require("fs");

// const filePath = "./dist/bundle.js";

// fs.readFile(filePath, "utf8", (err, data) => {
//   if (err) {
//     console.error(`Error reading file ${filePath}:`, err);
//     return;
//   }

//   const modifiedData = data.replace(/"use strict";/g, "");

//   fs.writeFile(filePath, modifiedData, "utf8", (err) => {
//     if (err) {
//       console.error(`Error writing file ${filePath}:`, err);
//     } else {
//       console.log(`Removal complete for file: ${filePath}`);
//     }
//   });
// });
