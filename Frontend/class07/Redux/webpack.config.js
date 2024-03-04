const ReactRefreshWebpackPlugin = require('@pmmmwh/react-refresh-webpack-plugin')
const ReactRefreshTypeScript = require('react-refresh-typescript')


const path = require('path')


// const isDevelopment = process.env.NODE_ENV !== 'production' 
const isDevelopment = true

module.exports = {
    entry: './src/index.tsx',
    // mode: isDevelopment ? 'development' : 'production',
    mode: 'development',
    devServer: {
        port: 7000,
        hot: true,

    },
    output: {
        path: path.resolve(__dirname, 'dist'),
        publicPath: '/dist/',
        filename: 'kawas.js'
    },
    module: {
        rules: [
            {
                test: /\.[jt]sx?$/,
                exclude: /node_modules/,
                use: [
                    {
                        loader: require.resolve('ts-loader'),
                        options: {
                            getCustomTransformers: () => ({
                                before: [ isDevelopment && ReactRefreshTypeScript() ].filter(Boolean)
                            }),
                            transpileOnly: isDevelopment
                        },
                    },
                ],
            },
            {
                test: /\.s[ac]ss$/i,
                use: [
                    // Creates `style` nodes from JS strings
                    "style-loader",
                    // Translates CSS into CommonJS
                    "css-loader",
                    // Compiles Sass to CSS
                    "sass-loader",
                ],
            }
        ],
    },
    resolve: { extensions: [ '*', '.js', '.jsx', '.tsx', '.ts' ] },
    plugins: [ isDevelopment && new ReactRefreshWebpackPlugin() ].filter(Boolean)

}